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
    public class AppointmentRepository
    {
        HospitalDbContext _context = new HospitalDbContext();  //veritabanı

        public List<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }
        public Appointment GetById(int id)
        {
            return _context.Appointments.Find(id);
        }
        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);  //Ara katmana ekler.
            _context.SaveChanges();         //veritabanıyla eşleştirir.
        }
        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }
        public void Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }
    }
}
