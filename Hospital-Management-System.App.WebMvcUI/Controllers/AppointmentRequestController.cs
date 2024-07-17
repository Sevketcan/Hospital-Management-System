using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.Services;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    [Authorize]
    public class AppointmentRequestController : Controller
    {
        private readonly IAppointmentRequestService _service;
        private readonly IPatientService _patientService;
        private readonly ILogger<AppointmentRequestController> _logger;

        public AppointmentRequestController(IAppointmentRequestService service, IPatientService patientService, ILogger<AppointmentRequestController> logger)
        {
            _service = service;
            _patientService = patientService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Appointment()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                _logger.LogWarning("User not logged in");
                return RedirectToAction("Login", "Account");
            }

            var patient = await _patientService.GetPatientByIdAsync(int.Parse(userId));
            if (patient == null)
            {
                _logger.LogError("Patient not found for user ID: {UserId}", userId);
                return RedirectToAction("Error", "Home");
            }

            var model = new AppointmentRequestViewModel
            {
                Name = patient.Name,
                Email = patient.Mail,
                Phone = patient.PhoneNumber,
                PatientId = patient.Id,
                Hospitals = await _service.GetHospitalsAsync(),
                Doctors = new List<Doctor>() // Initialize as empty, to be populated via AJAX
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Appointment(AppointmentRequestViewModel model)
        {
            _logger.LogInformation("Received appointment request for patient ID: {PatientId}", model.PatientId);

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model is valid. Creating appointment for patient ID: {PatientId}", model.PatientId);
                await _service.CreateAppointmentRequestAsync(model);
                return RedirectToAction("Success");
            }
            else
            {
                _logger.LogWarning("Model state is invalid. Errors: {Errors}", ModelState.Values.SelectMany(v => v.Errors));
            }

            // If model state is invalid, repopulate dropdowns
            model.Hospitals = await _service.GetHospitalsAsync();
            model.Doctors = await _service.GetDoctorsByHospitalAsync(model.HospitalId);

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorsByHospital(int hospitalId)
        {
            var doctors = await _service.GetDoctorsByHospitalAsync(hospitalId);
            return Json(doctors.Select(d => new { d.Id, d.Name, d.Surname, d.BranchName }));
        }
    }
}
