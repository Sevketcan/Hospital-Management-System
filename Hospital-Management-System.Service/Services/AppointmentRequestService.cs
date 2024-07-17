using Hospital_Management_System.DataAccess.Contexts;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Services
{
    public class AppointmentRequestService : IAppointmentRequestService
    {
        private readonly HospitalDbContext _context;
        private readonly ILogger<AppointmentRequestService> _logger;

        public AppointmentRequestService(HospitalDbContext context, ILogger<AppointmentRequestService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateAppointmentRequestAsync(AppointmentRequestViewModel model)
        {
            _logger.LogInformation("Creating appointment for patient ID: {PatientId}", model.PatientId);

            var appointment = new Appointment
            {
                DateTime = model.AppointmentDate.Add(TimeSpan.Parse(model.AppointmentTime)),
                DoctorId = model.DoctorId,
                PatientId = model.PatientId
            };

            _context.Appointments.Add(appointment);
            var result = await _context.SaveChangesAsync();
            _logger.LogInformation("Appointment created with result: {Result}", result);
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsAsync()
        {
            return await _context.Hospitals.ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsByHospitalAsync(int hospitalId)
        {
            return await _context.Doctors.Where(d => d.HospitalId == hospitalId).ToListAsync();
        }
    }
}
