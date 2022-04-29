using System.ComponentModel.DataAnnotations;

namespace MusicApp.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login field is empty")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password field is empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}