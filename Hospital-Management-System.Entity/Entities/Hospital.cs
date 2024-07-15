using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Entities
{
    public class Hospital : BaseEntity
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [Required]
        public int AdminId { get; set; } = 1; // Set default value to 1


        public virtual List<Doctor> Doctors { get; set; }
        public virtual Admin Admin { get; set; }

    }
}
