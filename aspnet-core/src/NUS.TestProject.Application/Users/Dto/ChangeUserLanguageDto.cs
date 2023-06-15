using System.ComponentModel.DataAnnotations;

namespace NUS.TestProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}