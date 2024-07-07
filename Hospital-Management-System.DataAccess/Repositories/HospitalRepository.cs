using Hospital_Management_System.DataAccess.Contexts;
using Hospital_Management_System.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DataAccess.Repositories
{
    public class HospitalRepository
    {
        HospitalDbContext _context = new HospitalDbContext();  //veritabanı

        public List<Hospital> GetAll()
        {
            return _context.Hospitals.ToList();
        }
        public Hospital GetById(int id)
        {
            return _context.Hospitals.Find(id);
        }
        public void Add(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);  //Ara katmana ekler.
            _context.SaveChanges();         //veritabanıyla eşleştirir.
        }
        public void Update(Hospital hospital)
        {
            _context.Hospitals.Update(hospital);
            _context.SaveChanges();
        }
        public void Delete(Hospital hospital)
        {
            _context.Hospitals.Remove(hospital);
            _context.SaveChanges();
        }
    }
}
