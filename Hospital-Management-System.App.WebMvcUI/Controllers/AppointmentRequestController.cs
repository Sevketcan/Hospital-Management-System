using Microsoft.AspNetCore.Mvc;
using Hospital_Management_System.Entity.Services;
using Hospital_Management_System.Entity.ViewModels;
using Hospital_Management_System.DataAccess.Repositories;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    public class AppointmentRequestController : Controller
    {
        private readonly IAppointmentRequestService _appointmentService;
        private readonly HospitalRepository _hospitalRepository;
        private readonly DoctorRepository _doctorRepository;

        public AppointmentRequestController(
            IAppointmentRequestService appointmentService,
            HospitalRepository hospitalRepository,
            DoctorRepository doctorRepository)
        {
            _appointmentService = appointmentService;
            _hospitalRepository = hospitalRepository;
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Appointment()
        {
            var hospitals = _hospitalRepository.GetAll();
            var doctors = _doctorRepository.GetAll();

            var model = new AppointmentRequestViewModel
            {
                Hospitals = hospitals,
                Doctors = doctors,
                PatientId = GetCurrentPatientId()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Appointment(AppointmentRequestViewModel model)
        {
            string msg = await _appointmentService.CreatAppointmentRequestAsync(model);
            if (msg == "OK")
            {
                return RedirectToAction("Index", "Home"); // Redirect to the home page
            }
            else
            {
                ModelState.AddModelError("", msg);
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public JsonResult GetDoctorsByHospital(int hospitalId)
        {
            var doctors = _doctorRepository.GetByHospitalId(hospitalId);
            return Json(doctors);
        }

        private int GetCurrentPatientId()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (claim != null && int.TryParse(claim.Value, out int patientId))
                {
                    return patientId;
                }
            }
            throw new Exception("Unable to determine current patient ID");
        }
    }
}
