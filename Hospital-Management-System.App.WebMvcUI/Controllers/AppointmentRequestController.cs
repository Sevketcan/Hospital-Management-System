using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospital_Management_System.Entity.Services;
using Hospital_Management_System.Entity.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    public class AppointmentRequestController : Controller
    {
        private readonly IAppointmentRequestService _appointmentService;


        public AppointmentRequestController(IAppointmentRequestService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Appointment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Appointment(AppointmentRequestViewModel model)
        {
            string msg = await _appointmentService.CreatAppointmentRequestAsync(model);
            if (msg == "OK")
            {
                return RedirectToAction("Success");
            }
            else
            {
                ModelState.AddModelError("", msg);
            }
            return View(model);
        }

    }
}
