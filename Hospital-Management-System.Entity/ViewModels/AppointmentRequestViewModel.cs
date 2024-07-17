using Hospital_Management_System.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Entity.ViewModels
{
    public class AppointmentRequestViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public int HospitalId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string AppointmentTime { get; set; }

        public int PatientId { get; set; } // Ensure this property is included

        public IEnumerable<Hospital> Hospitals { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}
