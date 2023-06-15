using System.ComponentModel.DataAnnotations;

namespace NUS.StudentIntegrity.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}