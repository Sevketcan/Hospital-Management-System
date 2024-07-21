using Hospital_Management_System.DataAccess.Repositories;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    [Authorize(Roles = "admin,hospital,doctor")]
    public class DoctorController : Controller
    {
        private readonly DoctorRepository _doctorRepo;
        private readonly AppointmentRepository _appointmentRepo;
        private readonly PrescriptionRepository _prescriptionRepo;

        public DoctorController(DoctorRepository doctorRepo, AppointmentRepository appointmentRepo, PrescriptionRepository prescriptionRepo)
        {
            _doctorRepo = doctorRepo;
            _appointmentRepo = appointmentRepo;
            _prescriptionRepo = prescriptionRepo;
        }

        public IActionResult List(string? search)
        {
            var doctors = _doctorRepo.GetAll();
            if (search != null)
            {
                doctors = doctors.Where(p => p.Name.ToLower().Contains(search.ToLower().Trim())).ToList();
            }
            return View(doctors);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index(int? id)
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

            var appointments = _appointmentRepo.GetByDoctorId(id);
            var prescriptions = _prescriptionRepo.GetByDoctorId(id);

            var viewModel = new DoctorDetailsViewModel
            {
                Doctors = doctor,
                Appointments = appointments,
                Prescriptions = prescriptions
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
            _doctorRepo.Add(model);
            return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var doctor = _doctorRepo.GetById(id);
            _doctorRepo.Delete(doctor);
            return RedirectToAction("Index", "Home");
        }
    }
}
