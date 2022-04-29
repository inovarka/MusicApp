using System.ComponentModel.DataAnnotations;

namespace MusicApp.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Login field is empty")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password field is empty")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password field is empty")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}