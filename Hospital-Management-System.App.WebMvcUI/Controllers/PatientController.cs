using Hospital_Management_System.DataAccess.Repositories;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    [Authorize(Roles = "admin,hospital,doctor,patient")]
    public class PatientController : Controller
    {
        private readonly PatientRepository _patientRepo;

        public PatientController(PatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public IActionResult List(string? search)
        {
            var patients = _patientRepo.GetAll();
            if (search != null)
            {
                patients = patients.Where(p => p.Name.ToLower().Contains(search.ToLower().Trim())).ToList();
            }
            return View(patients);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index(int? id)
        {
            var patients = _patientRepo.GetAll();
            return View(patients);
        }

        public IActionResult Details(int id)
        {
            var patient = _patientRepo.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            var appointments = _patientRepo.GetAppointmentsByPatientId(id);
            var prescriptions = _patientRepo.GetPrescriptionsByPatientId(id);

            var viewModel = new PatientDetailsViewModel
            {
                Patients = patient,
                Appointments = appointments,
                Prescriptions = prescriptions
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_patientRepo.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient model)
        {
            _patientRepo.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_patientRepo.GetAll(), "Id", "Name");
            var patient = _patientRepo.GetById(id);
            return View(patient);
        }

        [HttpPost]
        public IActionResult Edit(Patient model)
        {
            _patientRepo.Update(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var patient = _patientRepo.GetById(id);
            _patientRepo.Delete(patient);
            return RedirectToAction("Index", "Home");
        }
    }
}
