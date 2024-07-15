using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Entity.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; } // Add this line

        public string ReturnUrl { get; set; }
    }
}
