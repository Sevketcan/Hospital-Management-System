using Hospital_Management_System.DataAccess.Contexts;
using Hospital_Management_System.DataAccess.Repositories;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Services
{
    public class AppointmentRequestService : IAppointmentRequestService
    {
        private readonly HospitalDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppointmentRequestService(HospitalDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> CreatAppointmentRequestAsync(AppointmentRequestViewModel model)
        {
            var appointment = new Appointment
            {
                DateTime = model.DateTime,
                HospitalId = model.HospitalId,
                DoctorId = model.DoctorId,
                PatientId = model.PatientId,
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return "OK";
        }

    }
}
