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
    public class PrescriptionController : Controller
    {
        PrescriptionRepository _prescriptionRepo = new PrescriptionRepository();

        public IActionResult List(string? search)
        {
            var prescriptions = _prescriptionRepo.GetAll();
            if (search != null)
            {
				prescriptions = prescriptions.Where(p => p.MedicationName.ToLower().Contains(search.ToLower().Trim())).ToList();
            }
            return View(prescriptions);
        }

        public IActionResult Index(int? id)     //id -> categoryId
        {
            var prescriptions = _prescriptionRepo.GetAll();
            return View(prescriptions);
        }

        public IActionResult Details(int id)
        {
            var prescriptions = _prescriptionRepo.GetById(id);
            if (prescriptions == null)
            {
                return NotFound();
            }

            var prescription = _prescriptionRepo.GetAll().Where(d => d.DoctorId == id).ToList();



            return View(prescription);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_prescriptionRepo.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Prescription model)
        {
			_prescriptionRepo.Add(model);  // Formdan gelen Hospital modelini veritabanına ekler.
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_prescriptionRepo.GetAll(), "Id", "Name");
            var hospital = _prescriptionRepo.GetById(id);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Edit(Prescription model)
        {
			_prescriptionRepo.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prescription = _prescriptionRepo.GetById(id);
			_prescriptionRepo.Delete(prescription);
            return RedirectToAction("Index");
        }
    }
}
