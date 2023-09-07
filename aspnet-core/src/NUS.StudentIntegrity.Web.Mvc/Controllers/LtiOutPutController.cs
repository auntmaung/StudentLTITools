using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static NUS.StudentIntegrity.Web.Models.Constants;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NUS.StudentIntegrity.Controllers;
using NUS.StudentIntegrity.Web.Models.Account;
using NUS.StudentIntegrity.Authorization.LtiCanvas;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using NUS.StudentIntegrity.Web.Models;

namespace NUS.StudentIntegrity.Web.Controllers
{
    public class LtiOutPutController :  StudentIntegrityControllerBase
    {
        private string Error { get; set; }
        private string adminUser { get; set; }
        private ILtiCanvasAppService _LtiCanvasAppService { get; set; }
        public LtiOutPutController(ILtiCanvasAppService LtiCanvasAppService)
        {
            _LtiCanvasAppService = LtiCanvasAppService;
        }

        public async System.Threading.Tasks.Task<IActionResult> LtiResult(UserClaimData userdata)
        {
            if (userdata == null)
            {
                var value = HttpContext.Session.GetString("adminUser");
              //  userdata == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
                //userdata = HttpContext.Session.GetCustomObjectFromSession<UserClaimData>("adminUser");
            }


            var content = new StringBuilder();
            var xyz = "Hello";
            var iss = "https://canvas.instructure.com";
            var platform = await _LtiCanvasAppService.GetPlatformByIssuerAsync(iss);
            if (platform == null)
            {
                Error = "Unknown platform.";

                return Json(new { status = "error", message = Error });

                //return NotFound();
            }
            content.Append("Welcome To Canvas LTI" + userdata.version + " - ");
            ViewBag.Message = content;
            IList<UserClaimData> studentList = new List<UserClaimData>();

            if (userdata.Roles != null && userdata.Iss != null)
            {
                studentList.Add(userdata);

                //HttpContext.Session.SetObjectInSession("adminUser", userdata);
                HttpContext.Session.SetString("adminUser", JsonConvert.SerializeObject(userdata));
                HttpContext.Session.SetString("actions", xyz);
                TempData["name"] = "Testing";

            }
            else
            {


                if (TempData.ContainsKey("name"))
                    ViewBag.Name = TempData["name"] as string;

                TempData.Keep("name");

               UserClaimData _adminuser = HttpContext.Session.GetCustomObjectFromSession<UserClaimData>("adminUser");
                if (_adminuser != null)
                {
                    studentList.Add(_adminuser);
                }
                else
                {
                    var personWithBlondHair = ""
                + (char)int.Parse("D83DDC71".Substring(0, 4), NumberStyles.HexNumber)
                + (char)int.Parse("D83DDC71".Substring(4, 4), NumberStyles.HexNumber);

                    ViewBag.Message = ErrorMessage.Errors + personWithBlondHair;
                }
            }

            ViewData["userClaimdata"] = studentList;

            return View();
        }

    }
}
