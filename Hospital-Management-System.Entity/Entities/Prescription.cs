using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Entities
{
    public class Prescription :BaseEntity
    {

        public int Id { get; set; }
        public string MedicationName { get; set; }
        public DateOnly PrescriptionDate { get; set; }
        public string Usage { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        //Navigation Property Olarak PatientId gelecek
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }


    }
}
