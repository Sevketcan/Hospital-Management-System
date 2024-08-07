﻿using Hospital_Management_System.DataAccess.Contexts;
using Hospital_Management_System.DataAccess.Repositories;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hospital_Management_System.App.WebMvcUI.Controllers
{
    [Authorize(Roles = "admin,hospital,doctor,patient")]
    public class AppointmentController : Controller
    {
        private readonly HospitalDbContext _context;

        public AppointmentController(HospitalDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            // Database'den ilişkili entity'leri içeren randevuları getirin
            var appointments = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Hospital)
                .Include(a => a.Doctor)
                .ToList();

            return View(appointments);
        }

        AppointmentRepository _appointmentRepo = new AppointmentRepository();

        public IActionResult List(string? search)
        {
            var appointments = _appointmentRepo.GetAll();
            if (search != null)
    {
        search = search.ToLower().Trim();
        appointments = appointments.Where(p => p.DateTime.ToString().ToLower().Contains(search)).ToList();
    }
            return View(appointments);
        }

        //public IActionResult Index(int? id)     //id -> categoryId
        //{
        //    var appointments = _appointmentRepo.GetAll();
        //    return View(appointments);
        //}

        public IActionResult Details(int Id)
        {
            var appointments = _appointmentRepo.GetById(Id);
            if (appointments == null)
            {
                return NotFound();
            }

            var appointment = _appointmentRepo.GetAll().Where(d => d.DoctorId == Id).ToList();



            return View(appointment);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_appointmentRepo.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment model)
        {
			_appointmentRepo.Add(model);  // Formdan gelen Hospital modelini veritabanına ekler.
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_appointmentRepo.GetAll(), "Id", "Name");
			var appointment = _appointmentRepo.GetById(id);
            return View(appointment);
        }

        [HttpPost]
        public IActionResult Edit(Appointment model)
        {
			_appointmentRepo.Update(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var appointment = _appointmentRepo.GetById(id);
			_appointmentRepo.Delete(appointment);
            return RedirectToAction("Index", "Home");
        }
    }
}
