using System.ComponentModel.DataAnnotations;

namespace PontoDeAjuda.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}