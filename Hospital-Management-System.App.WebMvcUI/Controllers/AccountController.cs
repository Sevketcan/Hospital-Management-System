using Hospital_Management_System.Entity.Services;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        public IActionResult Login(string? returnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
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
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.Value.ToString()),
                    new Claim(ClaimTypes.Name, model.Username),
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

                if (role == "admin")
                {
                    return RedirectToAction("Index", "Admin");
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
