using System.Threading.Tasks;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using Hospital_Management_System.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Hospital_Management_System.Entity.Services
{
    public class AccountService : IAccountService
    {
        private readonly HospitalDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(HospitalDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> CreateUserAsync(RegisterViewModel model)
        {
            var patient = new Patient
            {
                Name = model.FirstName,
                Surname = model.LastName,
                Mail = model.Email,
                PhoneNumber = model.PhoneNumber,
                Username = model.Username,
                Password = model.Password, // Not: Şifreleme işlemi burada yapılmalıdır.
                Adress = model.Adress,
                TcNumber = model.TcNumber // Ensure this field is being set
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return "OK";
        }

        public async Task<(string, int?, string)> FindByNameAsync(LoginViewModel model)
        {
            var user = await _context.Patients
                .FirstOrDefaultAsync(p => p.Username == model.Username && p.Password == model.Password);

            if (user != null)
            {
                return ("OK", user.Id, "patient");
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.UserName == model.Username && a.Password == model.Password);

            if (admin != null)
            {
                return ("OK", admin.Id, "admin");
            }

            var hospital = await _context.Hospitals
                .FirstOrDefaultAsync(h => h.Username == model.Username && h.Password == model.Password);

            if (hospital != null)
            {
                return ("OK", hospital.Id, "hospital");
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(d => d.Username == model.Username && d.Password == model.Password);

            if (doctor != null)
            {
                return ("OK", doctor.Id, "doctor");
            }

            return ("kullanıcı bulunamadı!", null, null);
        }

        public async Task<UserViewModel> Find(string username)
        {
            var user = await _context.Patients.FirstOrDefaultAsync(p => p.Username == username);
            if (user == null) return null;

            return new UserViewModel
            {
                Username = user.Username,
                FirstName = user.Name,
                LastName = user.Surname,
                PhoneNumber = user.PhoneNumber,
                Email = user.Mail
            };
        }

        public async Task<string> CreateRoleAsync(RoleViewModel model)
        {
            // Implement role creation logic here
            return "OK";
        }

        public async Task<List<RoleViewModel>> GetAllRoles()
        {
            // Implement get all roles logic here
            return new List<RoleViewModel>();
        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
