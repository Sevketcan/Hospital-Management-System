using Hospital_Management_System.DataAccess.Repositories;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    [Authorize(Roles = "hospital,admin")]
    public class HospitalController : Controller
    {
        HospitalRepository _hospitalRepo = new HospitalRepository();
        DoctorRepository _doctorRepo = new DoctorRepository();

        public IActionResult List(string? search)
        {
            var hospitals = _hospitalRepo.GetAll();
            if (search != null)
            {
                hospitals = hospitals.Where(p => p.Name.ToLower().Contains(search.ToLower().Trim())).ToList();
            }
            return View(hospitals);
        }

        public IActionResult Index(int? id)     //id -> categoryId
        {
            var hospitals = _hospitalRepo.GetAll();
            return View(hospitals);
        }

        public IActionResult Details(int id)
        {
            var hospital = _hospitalRepo.GetById(id);
            if (hospital == null)
            {
                return NotFound();
            }

            var doctors = _doctorRepo.GetAll().Where(d => d.HospitalId == id).ToList();

            var viewModel = new HospitalDetailsViewModel
            {
                Hospital = hospital,
                Doctors = doctors
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_hospitalRepo.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hospital model)
        {
            _hospitalRepo.Add(model);  // Formdan gelen Hospital modelini veritabanına ekler.
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_hospitalRepo.GetAll(), "Id", "Name");
            var hospital = _hospitalRepo.GetById(id);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Edit(Hospital model)
        {
            _hospitalRepo.Update(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var hospital = _hospitalRepo.GetById(id);
            _hospitalRepo.Delete(hospital);
            return RedirectToAction("Index", "Home");
        }
    }
}
