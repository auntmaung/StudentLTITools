using System.Collections.Generic;

namespace NUS.StudentIntegrity.Web.Models.Account
{
    public class UserClaimData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Iss { get; set; }
        public string Label { get; set; }


        public string Title { get; set; }

        public string version { get; set; }

        public string token { get; set; }

        public string courseId { get; set; }

        public List<string> Roles { get; set; }

        public List<string> CourseRoles { get; set; }

    }
}
