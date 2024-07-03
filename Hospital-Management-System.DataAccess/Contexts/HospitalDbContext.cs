using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DataAccess.Contexts
{
    public class HospitalDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
    }
}
