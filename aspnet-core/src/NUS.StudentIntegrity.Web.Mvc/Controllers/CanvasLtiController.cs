using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using  Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUS.StudentIntegrity.Web.Models.Account;
using NUS.StudentIntegrity.Authorization.LtiCanvas;
using NUS.StudentIntegrity.Web.Models;
using static NUS.StudentIntegrity.Web.Models.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Collections.Specialized.BitVector32;
using NUS.StudentIntegrity.Controllers;
//using StudentInnovationPortal.Data;
//using StudentInnovationPortal.Models;
//using StudentInnovationPortal.Pages;
//using StudentInnovationPortal.Utility;
//using static StudentInnovationPortal.lib.Constants;


namespace NUS.StudentIntegrity.Web.Controllers
{
    public class CanvasLtiController : StudentIntegrityControllerBase
    {

       // private readonly ProviderContext _context;
        private string adminUser { get; set; }
        private ILtiCanvasAppService _LtiCanvasAppService { get; set; }
        private string Error { get; set; }

        //private readonly StateDbContext _stateContext;
        private IMemoryCache _cache;

        private readonly ILogger<CanvasLtiController> _logger;
        public CanvasLtiController( ILogger<CanvasLtiController> logger, IMemoryCache memoryCache, ILtiCanvasAppService LtiCanvasAppService)
        {
         
            _logger = logger;
            _cache = memoryCache;
            _LtiCanvasAppService = LtiCanvasAppService;
        }

        [HttpPost]
        public async Task<IActionResult> OidcLogin([FromBody] OidcLoginDetails oidcLogin)
        {

            var iss = oidcLogin.Iss;
            var login_hint = oidcLogin.Login_Hint;
            var client_id = oidcLogin.Client_Id;
            var target_link_uri = oidcLogin.Target_Link_Uri;
            var lti_message_hint = oidcLogin.Lti_Message_Hint;
            var canvas_region = oidcLogin.Canvas_Region;

            if (string.IsNullOrWhiteSpace(iss))
            {
                _logger.LogError(new ArgumentNullException(nameof(iss)), $"{nameof(iss)} is missing.");
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(login_hint))
            {
                _logger.LogError(new ArgumentNullException(nameof(login_hint)), $"{nameof(login_hint)} is missing.");
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(lti_message_hint))
            {
                _logger.LogError(new ArgumentNullException(nameof(lti_message_hint)), $"{nameof(lti_message_hint)} is missing.");
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(target_link_uri))
            {
                _logger.LogError(new ArgumentNullException(nameof(target_link_uri)), $"{nameof(target_link_uri)} is missing.");
                return BadRequest();
            }
            var platform = await _LtiCanvasAppService.GetPlatformByIssuerAsync(iss);
            if (platform == null)
            {
                _logger.LogError($"Issuer not found [{iss}].");
                return BadRequest();
            }
            if (!Uri.TryCreate(oidcLogin.Target_Link_Uri, UriKind.Absolute, out var targetLinkUri))
            {
                _logger.LogError($"Invalid target_link_uri [{target_link_uri}].");
                return BadRequest();
            }
            var nonce = CryptoRandom.CreateUniqueId();
            var state = CryptoRandom.CreateUniqueId();
            //_stateContext.AddState(nonce, state);
            var ru = new RequestUrl(platform.AuthorizeUrl);
            var content = new StringBuilder();
            var url = ru.CreateAuthorizeUrl
            (
                clientId: client_id,
                responseType: OidcConstants.ResponseTypes.IdToken,
                responseMode: OidcConstants.ResponseModes.FormPost,
                redirectUri: oidcLogin.Target_Link_Uri,
                scope: OidcConstants.StandardScopes.OpenId,
                state: state,
                loginHint: login_hint,
                nonce: nonce,
                prompt: "none"
            );

            _logger.LogInformation("Requesting id_token.");

            content.Append("&");
            content.Append("lti_message_hint=");
            content.Append(oidcLogin.Lti_Message_Hint);
            url += content.ToString();

            return Redirect(url);

        }


        [HttpPost]
        public async Task<ActionResult> LaunchLTI([FromBody] UserIdTokenDetails userIdTokenDetails)
        {

            string CanvasAccountId = userIdTokenDetails.CanvasAccountId;


            dynamic id_token = userIdTokenDetails.Id_Token;

            var handler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = handler.ReadJwtToken(id_token);

            var tokenS = jwtSecurityToken as JwtSecurityToken;

            var lisObj = tokenS.Claims.First(claim => claim.Type == LtiClaims.Lis).Value;
            var courseObj = tokenS.Claims.First(claim => claim.Type == LtiClaims.Context).Value;
            var ltiVersion = tokenS.Claims.First(claim => claim.Type == LtiClaims.Version).Value;
            var CanvasRolesObj = tokenS.Claims.First(claim => claim.Type == LtiClaims.Roles).Value;
            var CanvascustRolesObj = tokenS.Claims.First(claim => claim.Type == LtiClaims.Custom).Value;
            CourseDetails deCourseDetails = JsonConvert.DeserializeObject<CourseDetails>(courseObj);

            CanvasCustRoles canvasCustRolesV = JsonConvert.DeserializeObject<CanvasCustRoles>(CanvascustRolesObj);

            var CanvasMembershipRolesObj = canvasCustRolesV.Membershiprole;

            string[] fCanvasMembershipRolesObj = CanvasMembershipRolesObj.Split(',');

            //var roles = PemHelper.GetUserRoles(fCanvasMembershipRolesObj);

            // var courseRoles = PemHelper.GetUserCourseRoles(fCanvasMembershipRolesObj);
            var requestParams = Request.Form;

         
            //var courseCode = deCourseDetails.Label;
            //var coursetitle = deCourseDetails.Title;
            var claimObj = new
            {
                name = tokenS.Claims.First(claim => claim.Type == OidcClaims.Name).Value,
                email = tokenS.Claims.First(claim => claim.Type == OidcClaims.Email).Value,
                iss = tokenS.Claims.First(claim => claim.Type == OidcClaims.PlatformId).Value,
                label = deCourseDetails.Label,
                title = deCourseDetails.Title,
                version = ltiVersion,
                roles = PemHelper.GetUserRoles(fCanvasMembershipRolesObj),
                courseRoles= PemHelper.GetUserCourseRoles(fCanvasMembershipRolesObj),
                courseId = canvasCustRolesV.CanvasCourseId


            };

            var platform = await _LtiCanvasAppService.GetPlatformByIssuerAsync(claimObj.iss);
            if (platform == null)
            {
                Error = "Unknown platform.";

                return Json(new { status = "error", message = Error });

                //return NotFound();
            }
           // HttpContext.Session.SetObjectInSession("adminUser", claimObj);
            HttpContext.Session.SetString("adminUser", JsonConvert.SerializeObject(claimObj));
            HttpContext.Session.SetString("CURRENT_COURSE_ID", canvasCustRolesV.CanvasCourseId.ToString());

            //var cacheEntryOptions = new MemoryCacheEntryOptions()
            // // Keep in cache for this time, reset time if accessed.
            // .SetSlidingExpiration(TimeSpan.FromSeconds(3));
            _cache.Remove("CURRENT_COURSE_ID");
            _cache.Set("CURRENT_COURSE_ID", canvasCustRolesV.CanvasCourseId.ToString());

            return RedirectToAction("LtiResult", "LtiOutput", claimObj);

        }

    }
}