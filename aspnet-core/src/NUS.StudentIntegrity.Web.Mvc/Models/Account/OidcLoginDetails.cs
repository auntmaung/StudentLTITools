namespace NUS.StudentIntegrity.Web.Models.Account
{
    public class OidcLoginDetails
    {

        public string Iss { get; set; }


        public string Login_Hint { get; set; }


        public string Client_Id { get; set; }


        public string Target_Link_Uri { get; set; }


        public string Lti_Message_Hint { get; set; }

        public string Canvas_Region { get; set; }
    }
}
