using Hospital_Management_System.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.ViewModels
{
    public class HospitalDetailsViewModel
    {
        public Hospital Hospital { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}