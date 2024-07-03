using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Entities
{
    public class Patient : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string TcNumber { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //nav
        public virtual List<Appointment> Appointments { get; set; }
        public virtual List<Prescription> Prescriptions { get; set; }

    }
}
