using Hospital_Management_System.Entity.Services;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var (msg, userId, role) = await _service.FindByNameAsync(model);
            if (msg == "kullanıcı bulunamadı!")
            {
                ModelState.AddModelError("", msg);
                return View(model);
            }
            else if (msg == "OK" && userId.HasValue)
            {
                // Create the identity and sign in the user
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, model.Username),
            new Claim("UserId", userId.Value.ToString()),
            new Claim(ClaimTypes.Role, role)
        };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true // you can set to false if you don't want to persist the login
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Redirect based on role
                if (role == "admin")
                {
                    return RedirectToAction("Index", "Admin", new { id = userId.Value });
                }
                else if (role == "hospital")
                {
                    return RedirectToAction("Details", "Hospital", new { id = userId.Value });
                }
                else if (role == "doctor")
                {
                    return RedirectToAction("Details", "Doctor", new { id = userId.Value });
                }
                else if (role == "patient")
                {
                    return RedirectToAction("Details", "Patient", new { id = userId.Value });
                }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
