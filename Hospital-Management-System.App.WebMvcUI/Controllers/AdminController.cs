using Hospital_Management_System.App.WebMvcUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
