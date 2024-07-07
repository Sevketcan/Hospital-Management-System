using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.ViewModels
{
	public class RegisterViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "İsim alanı boş geçilemez!")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Soyisim alanı boş geçilemez!")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Telefon alanı boş geçilemez!")]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "Email alanı boş geçilemez!")]
		[EmailAddress(ErrorMessage = "Email formatına uygun değil!")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
		[Display(Name = "Şifre")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Tekrar şifresi boş geçilemez!")]
		[Display(Name = "Şifre Tekrar")]
		[Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}
