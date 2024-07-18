using Hospital_Management_System.Entity.Entities;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Services
{
    public interface IPatientService
    {
        Task<Patient> GetPatientByIdAsync(int patientId);
    }
}
