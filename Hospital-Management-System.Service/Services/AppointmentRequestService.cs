using Hospital_Management_System.DataAccess.Repositories;
using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Services
{
    public class AppointmentRequestService : IAppointmentRequestService
    {
        private readonly HospitalRepository _hospitalRepo;
        private readonly DoctorRepository _doctorRepo;
        private readonly AppointmentRepository _appointmentRepo;

        public AppointmentRequestService(HospitalRepository hospitalRepo, DoctorRepository doctorRepo, AppointmentRepository appointmentRepo)
        {
            _hospitalRepo = hospitalRepo;
            _doctorRepo = doctorRepo;
            _appointmentRepo = appointmentRepo;
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsAsync()
        {
            return await Task.FromResult(_hospitalRepo.GetAll());
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsByHospitalAsync(int hospitalId)
        {
            return await Task.FromResult(_doctorRepo.GetDoctorsByHospital(hospitalId));
        }

        public async Task<bool> CreateAppointmentRequestAsync(AppointmentRequestViewModel model)
        {
            try
            {
                var appointment = new Appointment
                {
                    DateTime = model.DateTime,
                    DoctorId = model.DoctorId,
                    PatientId = model.PatientId
                };

                _appointmentRepo.Add(appointment);
                await Task.CompletedTask;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
