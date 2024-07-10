using Hospital_Management_System.DataAccess.Contexts;
using Hospital_Management_System.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DataAccess.Repositories
{
    public class PatientRepository
    {
        HospitalDbContext _context = new HospitalDbContext();  //veritabanı

        public List<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }
        public Patient GetById(int id)
        {
            return _context.Patients.Find(id);
        }
        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);  //Ara katmana ekler.
            _context.SaveChanges();         //veritabanıyla eşleştirir.
        }
        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }
        public void Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
    }
}
