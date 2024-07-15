using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Entity.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "İsim alanı boş geçilemez!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim alanı boş geçilemez!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş geçilemez!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Email formatına uygun değil!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Adres alanı boş geçilemez!")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "TC numarası boş geçilemez!")]
        public string TcNumber { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı boş geçilemez!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor!")]
        public string ConfirmPassword { get; set; }
    }
}
