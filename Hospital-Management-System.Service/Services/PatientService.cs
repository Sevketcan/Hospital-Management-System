using Hospital_Management_System.Entity.Entities;
using Hospital_Management_System.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalDbContext _context;

        public PatientService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Id == patientId);
        }
    }
}
