using Hospital_Management_System.DataAccess.Repositories;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    [Authorize(Roles = "admin,hospital,doctor")]
    public class DoctorController : Controller
    {
        DoctorRepository _doctorRepo = new DoctorRepository();
        AppointmentRepository _appointmentRepo = new AppointmentRepository();
        PrescriptionRepository _prescriptionRepo = new PrescriptionRepository();

        public IActionResult List(string? search)
        {
            var doctors = _doctorRepo.GetAll();
            if (search != null)
            {
				doctors = doctors.Where(p => p.Name.ToLower().Contains(search.ToLower().Trim())).ToList();
            }
            return View(doctors);
        }
        public IActionResult Index(int? id)     //id -> categoryId
        {
            var doctors = _doctorRepo.GetAll();
            return View(doctors);
        }
		public IActionResult Details(int id)
		{
			var doctor = _doctorRepo.GetById(id);
			if (doctor == null)
			{
				return NotFound();
			}
			var appointments = _appointmentRepo.GetAll().Where(d => d.DoctorId == id).ToList();
			var prescriptions = _prescriptionRepo.GetAll().Where(d => d.DoctorId == id).ToList();

			var viewModel = new DoctorDetailsViewModel
			{
                Doctors = doctor,
                Appointments =  appointments,
                Prescriptions  =  prescriptions
			};

			return View(viewModel);
		}

		[HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_doctorRepo.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor model)
        {
            _doctorRepo.Add(model);  //Formdan gelen Product modelini veritabanına ekler.
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_doctorRepo.GetAll(), "Id", "Name");
            var doctor = _doctorRepo.GetById(id);
            return View(doctor);
		}
		[HttpPost]
        public IActionResult Edit(Doctor model)
        {
            _doctorRepo.Update(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var doctor = _doctorRepo.GetById(id);
            _doctorRepo.Delete(doctor);
            return RedirectToAction("Index");
        }
    }
}
