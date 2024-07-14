using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.ViewModels
{
	public class LoginViewModel
	{
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        [Display(Name = "Kullanıcı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
