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
    public class DoctorRepository
    {
        HospitalDbContext _context = new HospitalDbContext();  //veritabanı

        public List<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }
        public Doctor GetById(int id)
        {
            return _context.Doctors.Find(id);
        }
        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);  //Ara katmana ekler.
            _context.SaveChanges();         //veritabanıyla eşleştirir.
        }
        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }
        public void Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
        public List<Doctor> GetByHospitalId(int hospitalId)
        {
            return _context.Doctors.Where(d => d.HospitalId == hospitalId).ToList();
        }
        public List<Doctor> GetDoctorsByHospitalId(int hospitalId)
        {
            return _context.Doctors
                .Where(d => d.HospitalId == hospitalId)
                .ToList();
        }
    }
}
