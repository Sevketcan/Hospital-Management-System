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
            var hospitals = await _appointmentService.GetHospitalsAsync();
            var viewModel = new AppointmentRequestViewModel
            {
                Hospitals = hospitals
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Appointment(AppointmentRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = await _appointmentService.CreateAppointmentRequestAsync(model);
                if (result)
                {
                    ViewBag.Success = true;
                }
                else
                {
                    ViewBag.Success = false;
                }
                return View(model);
            }
            // If ModelState is not valid, return the view with validation errors
            var hospitals = await _appointmentService.GetHospitalsAsync();
            model.Hospitals = hospitals;
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetDoctorsByHospital(int hospitalId)
        {
            var doctors = await _appointmentService.GetDoctorsByHospitalAsync(hospitalId);
            var doctorList = doctors.Select(d => new {
                id = d.Id,
                name = $"{d.Name} {d.Surname} - {d.BranchName}"
            });
            return Json(doctorList);
        }
    }
}
