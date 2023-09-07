using Newtonsoft.Json;
using System.Collections.Generic;

namespace NUS.StudentIntegrity.Web.Models.Account
{
    public class UserIdTokenDetails
    {

        public string Utf8 { get; set; }
        public string Authenticity_Token { get; set; }
        public string Id_Token { get; set; }
        public string State { get; set; }
        public string CanvasAccountId { get; set; }

    }

    public class Errors
    {
        public Errors errors { get; set; }
    }

    public class CourseDetails
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Title { get; set; }
        public List<string> Type { get; set; }
        public object Validation_Context { get; set; }
        public Errors Errors { get; set; }
    }

    public class CanvasRoles
    {
        [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/roles")]
        public List<string> HttpsPurlImsglobalOrgSpecLtiClaimRoles { get; set; }
    }

    public class CanvasCustRoles
    {
        public string Membershiprole { get; set; }
        public int Canvas_User_Id { get; set; }
        public int CanvasCourseId { get; set; }
    }

    public class usertoken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public LtiUser user { get; set; }
        public string canvas_region { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
    }

    public class LtiUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string global_id { get; set; }
        public string effective_locale { get; set; }
    }
}
