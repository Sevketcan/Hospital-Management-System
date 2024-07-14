using Hospital_Management_System.Entity.Entities;

namespace Hospital_Management_System.Entity.ViewModels
{
    public class DoctorDetailsViewModel
	{
		public Doctor Doctors { get; set; }

		public List<Appointment> Appointments { get; set; }
		public List<Prescription> Prescriptions { get; set; }

	}
}
