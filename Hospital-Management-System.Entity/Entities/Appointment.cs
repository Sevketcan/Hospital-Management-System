using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Entities
{
    public class Appointment : BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int DoctorId { get; set; }
        public int PatientId {  get; set; }

        //Nav property olarak patient İd verilecek

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
