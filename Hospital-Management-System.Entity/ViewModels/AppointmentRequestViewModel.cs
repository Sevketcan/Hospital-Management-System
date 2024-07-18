using Hospital_Management_System.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Entity.ViewModels
{
    public class AppointmentRequestViewModel
    {
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int HospitalId { get; set; } // Add this property

        public IEnumerable<Hospital> Hospitals { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}
