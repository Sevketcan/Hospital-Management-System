﻿using Hospital_Management_System.DataAccess.Contexts;
using Hospital_Management_System.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DataAccess.Repositories
{
    public class PrescriptionRepository
    {
        HospitalDbContext _context = new HospitalDbContext();  //veritabanı

        public List<Prescription> GetAll()
        {
            return _context.Prescriptions.Include(p => p.Patient).ToList();
        }
        public Prescription GetById(int id)
        {
            return _context.Prescriptions.Find(id);
        }
        public List<Prescription> GetByDoctorId(int doctorId)
        {
            return _context.Prescriptions
                .Where(p => p.DoctorId == doctorId)
                .Include(p => p.Patient)
                .ToList();
        }
        public void Add(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);  //Ara katmana ekler.
            _context.SaveChanges();         //veritabanıyla eşleştirir.
        }
        public void Update(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            _context.SaveChanges();
        }
        public void Delete(Prescription prescription)
        {
            _context.Prescriptions.Remove(prescription);
            _context.SaveChanges();
        }
    }
}
