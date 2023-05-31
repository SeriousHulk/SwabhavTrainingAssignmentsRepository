using System.ComponentModel.DataAnnotations;

namespace login_welcome_app.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username Required!")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password Required!")]
        public string? UserPassword { get; set; }
        public string? Title { get; set; }
    }
}