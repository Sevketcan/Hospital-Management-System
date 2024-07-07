using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.DataAccess.Identity;
using Hospital_Management_System.Entity.Entities;

namespace Hospital_Management_System.DataAccess.Contexts
{
	public class HospitalDbContext : IdentityDbContext<AppUser, AppRole, int>
	{
        public HospitalDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=93.89.230.2;Initial Catalog=hosp_db;Persist Security Info=True;User ID=admin_wissen1;Password=Th%7k107o;Trust Server Certificate=True");
            }
        }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

		public DbSet<Admin> Admins { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Hospital> Hospitals { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Prescription> Prescriptions { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Fluent API validation
			builder.Entity<Admin>().Property(a => a.UserName).IsRequired().HasMaxLength(100);
			builder.Entity<Admin>().Property(a => a.Password).IsRequired().HasMaxLength(100);

			builder.Entity<Doctor>().Property(d => d.Name).IsRequired().HasMaxLength(100);
			builder.Entity<Doctor>().Property(d => d.Surname).IsRequired().HasMaxLength(100);
			builder.Entity<Doctor>().Property(d => d.BranchName).IsRequired().HasMaxLength(100);
			builder.Entity<Doctor>().Property(d => d.Username).IsRequired().HasMaxLength(100);
			builder.Entity<Doctor>().Property(d => d.Password).IsRequired().HasMaxLength(100);

			builder.Entity<Hospital>().Property(h => h.Name).IsRequired().HasMaxLength(200);
			builder.Entity<Hospital>().Property(h => h.Adress).IsRequired().HasMaxLength(200);
			builder.Entity<Hospital>().Property(h => h.PhoneNumber).IsRequired().HasMaxLength(20);

			builder.Entity<Patient>().Property(p => p.Name).IsRequired().HasMaxLength(100);
			builder.Entity<Patient>().Property(p => p.Surname).IsRequired().HasMaxLength(100);
			builder.Entity<Patient>().Property(p => p.Mail).IsRequired().HasMaxLength(100);
			builder.Entity<Patient>().Property(p => p.TcNumber).IsRequired().HasMaxLength(11);
			builder.Entity<Patient>().Property(p => p.Adress).IsRequired().HasMaxLength(200);
			builder.Entity<Patient>().Property(p => p.PhoneNumber).IsRequired().HasMaxLength(20);
			builder.Entity<Patient>().Property(p => p.Username).IsRequired().HasMaxLength(100);
			builder.Entity<Patient>().Property(p => p.Password).IsRequired().HasMaxLength(100);

			builder.Entity<Prescription>().Property(pr => pr.MedicationName).IsRequired().HasMaxLength(100);
			builder.Entity<Prescription>().Property(pr => pr.Usage).IsRequired().HasMaxLength(200);

			builder.Entity<Appointment>().Property(a => a.DateTime).IsRequired();

			// Seed Data
			builder.Entity<Admin>().HasData(
				new Admin { Id = 1, UserName = "admin1", Password = "admin123" }
			);

			builder.Entity<Hospital>().HasData(
				new Hospital { Id = 1, Name = "Central Hospital", Adress = "Main Street 1", PhoneNumber = "123456789", AdminId = 1 }
			);

			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 1, Name = "John", Surname = "Doe", BranchName = "Cardiology", PhoneNumber = "123456789", Username = "johndoe", Password = "password", HospitalId = 1 }
			);

			builder.Entity<Patient>().HasData(
				new Patient { Id = 1, Name = "Jane", Surname = "Smith", Mail = "jane.smith@example.com", TcNumber = "12345678901", Adress = "Main Street 2", PhoneNumber = "987654321", Username = "janesmith", Password = "password" }
			);

			builder.Entity<Prescription>().HasData(
				new Prescription { Id = 1, MedicationName = "Aspirin", PrescriptionDate = new DateOnly(2023, 1, 1), Usage = "Twice a day", PatientId = 1, DoctorId = 1 }
			);

			builder.Entity<Appointment>().HasData(
				new Appointment { Id = 1, DateTime = new DateTime(2023, 1, 1, 10, 0, 0), DoctorId = 1, PatientId = 1 }
			);
		}
	}
}
