using Hospital_Management_System.Entity.Services;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? ReturnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var (msg, userId) = await _service.FindByNameAsync(model);
            if (msg == "kullanıcı bulunamadı!")
            {
                ModelState.AddModelError("", msg);
                return View(model);
            }
            else if (msg == "OK" && userId.HasValue)
            {
                return RedirectToAction("Details", "Patient", new { id = userId.Value });
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            string msg = await _service.CreateUserAsync(model);
            if (msg == "OK")
            {
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", msg);
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _service.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
