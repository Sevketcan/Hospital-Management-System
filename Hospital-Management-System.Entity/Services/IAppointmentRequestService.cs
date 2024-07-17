using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Services
{
    public interface IAppointmentRequestService
    {
        Task<IEnumerable<Hospital>> GetHospitalsAsync();
        Task<IEnumerable<Doctor>> GetDoctorsByHospitalAsync(int hospitalId);
        Task CreateAppointmentRequestAsync(AppointmentRequestViewModel model); // Add this method
    }
}
