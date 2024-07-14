using Hospital_Management_System.DataAccess.Repositories;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    public class PatientController : Controller
    {
		PatientRepository _patientRepo = new PatientRepository();
        AppointmentRepository _appointmentRepo = new AppointmentRepository();
        PrescriptionRepository _prescriptionRepo = new PrescriptionRepository();

        public IActionResult List(string? search)
        {
            var patients = _patientRepo.GetAll();
            if (search != null)
            {
				patients = patients.Where(p => p.Name.ToLower().Contains(search.ToLower().Trim())).ToList();
            }
            return View(patients);
        }
        public IActionResult Index(int? id)     //id -> categoryId
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
            var appointments = _appointmentRepo.GetAll().Where(d => d.DoctorId == id).ToList();
            var prescriptions = _prescriptionRepo.GetAll().Where(d => d.DoctorId == id).ToList();

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
			_patientRepo.Add(model);  //Formdan gelen Product modelini veritabanına ekler.
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
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var patient = _patientRepo.GetById(id);
			_patientRepo.Delete(patient);
            return RedirectToAction("Index");
        }
    }
}
