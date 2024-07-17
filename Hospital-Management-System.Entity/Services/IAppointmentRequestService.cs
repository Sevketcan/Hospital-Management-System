using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Services
{
    public interface IAppointmentRequestService
    {
        Task CreateAppointmentRequestAsync(AppointmentRequestViewModel model);
        Task<IEnumerable<Hospital>> GetHospitalsAsync();
        Task<IEnumerable<Doctor>> GetDoctorsByHospitalAsync(int hospitalId);
    }
}
