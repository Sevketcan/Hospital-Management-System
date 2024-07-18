using Hospital_Management_System.DataAccess.Repositories;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.Services;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    [Authorize]
    public class AppointmentRequestController : Controller
    {
        AppointmentRepository _appointmentRepo = new AppointmentRepository();
        private readonly IAppointmentRequestService _service;
        private readonly IPatientService _patientService;
        private readonly ILogger<AppointmentRequestController> _logger;

        public AppointmentRequestController(
            IAppointmentRequestService service,
            IPatientService patientService,
            ILogger<AppointmentRequestController> logger)
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
                PatientId = patient.Id,
                Hospitals = await _service.GetHospitalsAsync(),
                Doctors = new List<Doctor>() // Initialize as empty, to be populated via AJAX
            };

            ViewBag.Categories = new SelectList(_appointmentRepo.GetAll(), "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Appointment(AppointmentRequestViewModel model)
        {
            _logger.LogInformation("Received appointment request for patient ID: {PatientId}", model.PatientId);

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model is valid. Creating appointment for patient ID: {PatientId}", model.PatientId);

                var success = await _service.CreateAppointmentRequestAsync(model);
                if (success)
                {
                    ViewBag.Success = true;
                    return View(model);
                }
                else
                {
                    ViewBag.Error = "Failed to create appointment due to an unknown error. Please try again.";
                    _logger.LogError("Failed to create appointment for patient ID: {PatientId}. Unknown error.", model.PatientId);
                }
            }
            else
            {
                _logger.LogWarning("Model state is invalid. Errors: {Errors}", ModelState.Values.SelectMany(v => v.Errors));
                ViewBag.Error = "Failed to create appointment due to validation errors. Please check your input.";
            }

            // Repopulate dropdowns and return the view with error details
            model.Hospitals = await _service.GetHospitalsAsync();
            model.Doctors = await _service.GetDoctorsByHospitalAsync(model.HospitalId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorsByHospital(int hospitalId)
        {
            var doctors = await _service.GetDoctorsByHospitalAsync(hospitalId);
            return Json(doctors.Select(d => new { d.Id, d.Name, d.Surname, d.BranchName }));
        }
    }
}
