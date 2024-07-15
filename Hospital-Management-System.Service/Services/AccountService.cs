using System.Threading.Tasks;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using Hospital_Management_System.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Entity.Services
{
    public class AccountService : IAccountService
    {
        private readonly HospitalDbContext _context;

        public AccountService(HospitalDbContext context)
        {
            _context = context;
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

        public async Task<(string, int?)> FindByNameAsync(LoginViewModel model)
        {
            var user = await _context.Patients
                .FirstOrDefaultAsync(p => p.Username == model.Username && p.Password == model.Password); // Not: Şifre doğrulama işlemi burada yapılmalıdır.

            if (user == null)
            {
                return ("kullanıcı bulunamadı!", null);
            }

            return ("OK", user.Id);
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
            // Implement sign out logic here
        }
    }
}
