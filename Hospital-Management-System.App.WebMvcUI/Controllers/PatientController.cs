using Hospital_Management_System.DataAccess.Repositories;
using Hospital_Management_System.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    public class PatientController : Controller
    {
		PatientController _patientRepo = new PatientController();

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
            return View(patient);
        }
		public IActionResult Details(int id)
		{
			var doctor = _patientRepo.GetById(id);
			if (doctor == null)
			{
				return NotFound();
			}
			return View(doctor);
		}

		[HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_patientRepo.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor model)
        {
			_patientRepo.Add(model);  //Formdan gelen Product modelini veritabanına ekler.
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_patientRepo.GetAll(), "Id", "Name");
            var doctor = _patientRepo.GetById(id);
            return View(doctor);
		}
		[HttpPost]
        public IActionResult Edit(Doctor model)
        {
			_patientRepo.Update(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var doctor = _patientRepo.GetById(id);
			_patientRepo.Delete(doctor);
            return RedirectToAction("Index");
        }
    }
}
