using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Entities
{
    public class Admin : BaseEntity
    {
        public int Id {  get; set; }
        public string UserName {  get; set; }
        public string Password {  get; set; }

        //NAV

        public virtual List<Hospital> Hospitals { get; set; }


    }
}
