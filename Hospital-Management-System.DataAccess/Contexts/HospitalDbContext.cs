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
				new Hospital { Id = 1, Name = "Central Hospital", Adress = "Kozyatağı, Kocayol Cd. No:19, 34742 Kadıköy/Istanbul", PhoneNumber = "0216 4447799", AdminId = 1 }
			);
			builder.Entity<Hospital>().HasData(
				new Hospital { Id = 2, Name = "Delta Hospital", Adress = "İdealtepe, Akgüvercin Sk. No:4, 34841 Maltepe/Istanbul", PhoneNumber = "02163889999", AdminId = 1 }
			);
			builder.Entity<Hospital>().HasData(
				new Hospital { Id = 3, Name = "Ibni Sina Hospital", Adress = "Küçükyalı, Merkez Mh, Talat Bey Sok. No:28/B, 34840 Maltepe/Istanbul", PhoneNumber = "02165180900", AdminId = 1 }
			);
			builder.Entity<Hospital>().HasData(
				new Hospital { Id = 4, Name = "Istanbul Onkoloji Hospital", Adress = "Cevizli, Talatpaşa Cd No:75, 34846 Maltepe/Istanbul", PhoneNumber = "02164573737", AdminId = 1 }
			);
			builder.Entity<Hospital>().HasData(
				new Hospital { Id = 5, Name = "Maltepe Ersoy Hospital", Adress = "Altayçeşme, Varna Sk. No:16, 34843 Maltepe/Istanbul", PhoneNumber = "085081186007", AdminId = 1 }
			);

			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 1, Name = "Sevket Can", Surname = "Kalyancioglu", BranchName = "Urology", PhoneNumber = "123456789", Username = "onlysevk", Password = "kalyancisevket", HospitalId = 1 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 2, Name = "John", Surname = "Doe", BranchName = "Cardiology", PhoneNumber = "123456789", Username = "johndoe", Password = "password", HospitalId = 1 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 3, Name = "Esmer", Surname = "HASANOVA", BranchName = "Gynecology and Obstetrics", PhoneNumber = "456123789", Username = "smerhasan", Password = "hasanesmr", HospitalId = 1 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 4, Name = "Sinem", Surname = "AKAY", BranchName = "Brain surgery", PhoneNumber = "127834569", Username = "aksikinem", Password = "rivakkayariv", HospitalId = 1 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 5, Name = "Faruk", Surname = "TUFEKCI", BranchName = "Psychiatry", PhoneNumber = "561278349", Username = "hellokityfaruk", Password = "faruk3131", HospitalId = 1 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 6, Name = "Museyip", Surname = "HAKKO", BranchName = "Internal Medicine Specialist", PhoneNumber = "527613849", Username = "museyipp", Password = "muss03169", HospitalId = 2 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 7, Name = "Osman", Surname = "Ozkeles", BranchName = "ENT Diseases Specialist", PhoneNumber = "561382749", Username = "usmankeles", Password = "613127", HospitalId = 2 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 8, Name = "Cezmi", Surname = "Tuncer", BranchName = "Child Health and Diseases Specialist", PhoneNumber = "527496138", Username = "tuncercezmi", Password = "8521613", HospitalId = 2 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 9, Name = "Zerrin", Surname = "Goksin", BranchName = "Eye Health and Diseases Specialist", PhoneNumber = "561749382", Username = "gokzerrin", Password = "631271", HospitalId = 2 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 10, Name = "Leyla", Surname = "Sonmez", BranchName = "Clinical Psychologist", PhoneNumber = "527461389", Username = "sonmezreis", Password = "131267", HospitalId = 2 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 11, Name = "Denizmen", Surname = "Aygün", BranchName = "Child Health and Diseases Specialist", PhoneNumber = "527461389", Username = "sonmezreis", Password = "131267", HospitalId = 3 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 12, Name = "Altay", Surname = "Iskender", BranchName = "Anesthesia and Reanimation", PhoneNumber = "574612389", Username = "sikender", Password = "112367", HospitalId = 3 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 13, Name = "Alaattin", Surname = "Ersoy", BranchName = "Child Health and Diseases", PhoneNumber = "523874619", Username = "ersoyyy", Password = "167312", HospitalId = 3 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 14, Name = "Aleyna", Surname = "Ergul", BranchName = "Nutrition and Diet", PhoneNumber = "538274619", Username = "ergulaleyna", Password = "213167", HospitalId = 3 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 15, Name = "Ali", Surname = "Kadayifci", BranchName = "Urologist", PhoneNumber = "513827469", Username = "alikadayifci", Password = "261317", HospitalId = 3 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 16, Name = "Emre", Surname = "YILDIRIM", BranchName = "Gastroenterology", PhoneNumber = "518274369", Username = "emreyildirim", Password = "261731", HospitalId = 4 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 17, Name = "Abdullah", Surname = "OZKAYA", BranchName = "Eye diseases", PhoneNumber = "582137469", Username = "abdullahockaya", Password = "231617", HospitalId = 4 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 18, Name = "Abdulmuttalip", Surname = "SIMSEK", BranchName = "Urologist", PhoneNumber = "382751469", Username = "abulsimsek", Password = "276131", HospitalId = 4 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 19, Name = "Abdurrahman", Surname = "ONEN", BranchName = "Boys Urologist", PhoneNumber = "274695138", Username = "onenabd", Password = "261371", HospitalId = 4 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 20, Name = "Furkan", Surname = "Keles", BranchName = "Patology", PhoneNumber = "5316678637", Username = "kelesfurkan", Password = "616161", HospitalId = 4 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 21, Name = "Mete Oguz", Surname = "Ekinci", BranchName = "Urologist", PhoneNumber = "138274659", Username = "meteoguz", Password = "271361", HospitalId = 5 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 22, Name = "Ekrem", Surname = "Aytac", BranchName = "Ear Nose Throat Diseases", PhoneNumber = "513898927469", Username = "ekerrmm", Password = "26117", HospitalId = 5 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 23, Name = "Ozer", Surname = "Celik", BranchName = "General Surgery", PhoneNumber = "51386527469", Username = "ozercelik", Password = "456875", HospitalId = 5 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 24, Name = "Bahri", Surname = "Muftuoglu", BranchName = "Eye Health and Diseases", PhoneNumber = "51382437469", Username = "bahri", Password = "26178317", HospitalId = 5 }
			);
			builder.Entity<Doctor>().HasData(
				new Doctor { Id = 25, Name = "Mehmet", Surname = "Beyli", BranchName = "Emergency room", PhoneNumber = "51382712469", Username = "memetbeyli", Password = "26212341317", HospitalId = 5 }
			);

			builder.Entity<Patient>().HasData(
				new Patient { Id = 1, Name = "Jane", Surname = "Smith", Mail = "jane.smith1@example.com", TcNumber = "12345678901", Adress = "Main Street 2", PhoneNumber = "987654321", Username = "janesmith1", Password = "password1" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 2, Name = "John", Surname = "Doe", Mail = "john.doe@example.com", TcNumber = "12345678902", Adress = "Main Street 3", PhoneNumber = "987654322", Username = "johndoe", Password = "password2" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 3, Name = "Alice", Surname = "Johnson", Mail = "alice.johnson@example.com", TcNumber = "12345678903", Adress = "Main Street 4", PhoneNumber = "987654323", Username = "alicejohnson", Password = "password3" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 4, Name = "Bob", Surname = "Brown", Mail = "bob.brown@example.com", TcNumber = "12345678904", Adress = "Main Street 5", PhoneNumber = "987654324", Username = "bobbrown", Password = "password4" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 5, Name = "Charlie", Surname = "Davis", Mail = "charlie.davis@example.com", TcNumber = "12345678905", Adress = "Main Street 6", PhoneNumber = "987654325", Username = "charliedavis", Password = "password5" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 6, Name = "David", Surname = "Wilson", Mail = "david.wilson@example.com", TcNumber = "12345678906", Adress = "Main Street 7", PhoneNumber = "987654326", Username = "davidwilson", Password = "password6" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 7, Name = "Emma", Surname = "Moore", Mail = "emma.moore@example.com", TcNumber = "12345678907", Adress = "Main Street 8", PhoneNumber = "987654327", Username = "emmamoore", Password = "password7" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 8, Name = "Frank", Surname = "Taylor", Mail = "frank.taylor@example.com", TcNumber = "12345678908", Adress = "Main Street 9", PhoneNumber = "987654328", Username = "franktaylor", Password = "password8" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 9, Name = "Grace", Surname = "Anderson", Mail = "grace.anderson@example.com", TcNumber = "12345678909", Adress = "Main Street 10", PhoneNumber = "987654329", Username = "graceanderson", Password = "password9" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 10, Name = "Henry", Surname = "Thomas", Mail = "henry.thomas@example.com", TcNumber = "12345678910", Adress = "Main Street 11", PhoneNumber = "987654330", Username = "henrythomas", Password = "password10" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 11, Name = "Ivy", Surname = "Jackson", Mail = "ivy.jackson@example.com", TcNumber = "12345678911", Adress = "Main Street 12", PhoneNumber = "987654331", Username = "ivyjackson", Password = "password11" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 12, Name = "Jack", Surname = "White", Mail = "jack.white@example.com", TcNumber = "12345678912", Adress = "Main Street 13", PhoneNumber = "987654332", Username = "jackwhite", Password = "password12" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 13, Name = "Kathy", Surname = "Harris", Mail = "kathy.harris@example.com", TcNumber = "12345678913", Adress = "Main Street 14", PhoneNumber = "987654333", Username = "kathyharris", Password = "password13" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 14, Name = "Liam", Surname = "Martin", Mail = "liam.martin@example.com", TcNumber = "12345678914", Adress = "Main Street 15", PhoneNumber = "987654334", Username = "liammartin", Password = "password14" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 15, Name = "Mia", Surname = "Lee", Mail = "mia.lee@example.com", TcNumber = "12345678915", Adress = "Main Street 16", PhoneNumber = "987654335", Username = "mialee", Password = "password15" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 16, Name = "Nathan", Surname = "Clark", Mail = "nathan.clark@example.com", TcNumber = "12345678916", Adress = "Main Street 17", PhoneNumber = "987654336", Username = "nathanclark", Password = "password16" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 17, Name = "Olivia", Surname = "Robinson", Mail = "olivia.robinson@example.com", TcNumber = "12345678917", Adress = "Main Street 18", PhoneNumber = "987654337", Username = "oliviarobinson", Password = "password17" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 18, Name = "Paul", Surname = "Lewis", Mail = "paul.lewis@example.com", TcNumber = "12345678918", Adress = "Main Street 19", PhoneNumber = "987654338", Username = "paullewis", Password = "password18" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 19, Name = "Quinn", Surname = "Walker", Mail = "quinn.walker@example.com", TcNumber = "12345678919", Adress = "Main Street 20", PhoneNumber = "987654339", Username = "quinnwalker", Password = "password19" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 20, Name = "Rachel", Surname = "Hall", Mail = "rachel.hall@example.com", TcNumber = "12345678920", Adress = "Main Street 21", PhoneNumber = "987654340", Username = "rachelhall", Password = "password20" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 21, Name = "Steve", Surname = "Young", Mail = "steve.young@example.com", TcNumber = "12345678921", Adress = "Main Street 22", PhoneNumber = "987654341", Username = "steveyoung", Password = "password21" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 22, Name = "Tina", Surname = "King", Mail = "tina.king@example.com", TcNumber = "12345678922", Adress = "Main Street 23", PhoneNumber = "987654342", Username = "tinaking", Password = "password22" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 23, Name = "Ursula", Surname = "Scott", Mail = "ursula.scott@example.com", TcNumber = "12345678923", Adress = "Main Street 24", PhoneNumber = "987654343", Username = "ursulascott", Password = "password23" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 24, Name = "Victor", Surname = "Adams", Mail = "victor.adams@example.com", TcNumber = "12345678924", Adress = "Main Street 25", PhoneNumber = "987654344", Username = "victoradams", Password = "password24" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 25, Name = "Wendy", Surname = "Evans", Mail = "wendy.evans@example.com", TcNumber = "12345678925", Adress = "Main Street 26", PhoneNumber = "987654345", Username = "wendyevans", Password = "password25" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 26, Name = "Xavier", Surname = "Baker", Mail = "xavier.baker@example.com", TcNumber = "12345678926", Adress = "Main Street 27", PhoneNumber = "987654346", Username = "xavierbaker", Password = "password26" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 27, Name = "Yara", Surname = "Parker", Mail = "yara.parker@example.com", TcNumber = "12345678927", Adress = "Main Street 28", PhoneNumber = "987654347", Username = "yaraparker", Password = "password27" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 28, Name = "Zach", Surname = "Cook", Mail = "zach.cook@example.com", TcNumber = "12345678928", Adress = "Main Street 29", PhoneNumber = "987654348", Username = "zachcook", Password = "password28" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 29, Name = "Adam", Surname = "Reed", Mail = "adam.reed@example.com", TcNumber = "12345678929", Adress = "Main Street 30", PhoneNumber = "987654349", Username = "adamreed", Password = "password29" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 30, Name = "Bella", Surname = "Wright", Mail = "bella.wright@example.com", TcNumber = "12345678930", Adress = "Main Street 31", PhoneNumber = "987654350", Username = "bellawright", Password = "password30" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 31, Name = "Chris", Surname = "Green", Mail = "chris.green@example.com", TcNumber = "12345678931", Adress = "Main Street 32", PhoneNumber = "987654351", Username = "chrisgreen", Password = "password31" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 32, Name = "Diana", Surname = "Hill", Mail = "diana.hill@example.com", TcNumber = "12345678932", Adress = "Main Street 33", PhoneNumber = "987654352", Username = "dianahill", Password = "password32" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 33, Name = "Ethan", Surname = "Scott", Mail = "ethan.scott@example.com", TcNumber = "12345678933", Adress = "Main Street 34", PhoneNumber = "987654353", Username = "ethanscott", Password = "password33" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 34, Name = "Fiona", Surname = "Morris", Mail = "fiona.morris@example.com", TcNumber = "12345678934", Adress = "Main Street 35", PhoneNumber = "987654354", Username = "fionamorris", Password = "password34" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 35, Name = "George", Surname = "Cooper", Mail = "george.cooper@example.com", TcNumber = "12345678935", Adress = "Main Street 36", PhoneNumber = "987654355", Username = "georgecooper", Password = "password35" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 36, Name = "Hannah", Surname = "Nelson", Mail = "hannah.nelson@example.com", TcNumber = "12345678936", Adress = "Main Street 37", PhoneNumber = "987654356", Username = "hannahnelson", Password = "password36" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 37, Name = "Ian", Surname = "Mitchell", Mail = "ian.mitchell@example.com", TcNumber = "12345678937", Adress = "Main Street 38", PhoneNumber = "987654357", Username = "ianmitchell", Password = "password37" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 38, Name = "Jenna", Surname = "Perez", Mail = "jenna.perez@example.com", TcNumber = "12345678938", Adress = "Main Street 39", PhoneNumber = "987654358", Username = "jennaperez", Password = "password38" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 39, Name = "Kyle", Surname = "Roberts", Mail = "kyle.roberts@example.com", TcNumber = "12345678939", Adress = "Main Street 40", PhoneNumber = "987654359", Username = "kyleroberts", Password = "password39" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 40, Name = "Laura", Surname = "Phillips", Mail = "laura.phillips@example.com", TcNumber = "12345678940", Adress = "Main Street 41", PhoneNumber = "987654360", Username = "lauraphillips", Password = "password40" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 41, Name = "Mark", Surname = "Campbell", Mail = "mark.campbell@example.com", TcNumber = "12345678941", Adress = "Main Street 42", PhoneNumber = "987654361", Username = "markcampbell", Password = "password41" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 42, Name = "Nina", Surname = "Parker", Mail = "nina.parker@example.com", TcNumber = "12345678942", Adress = "Main Street 43", PhoneNumber = "987654362", Username = "ninaparker", Password = "password42" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 43, Name = "Oscar", Surname = "Bennett", Mail = "oscar.bennett@example.com", TcNumber = "12345678943", Adress = "Main Street 44", PhoneNumber = "987654363", Username = "oscarbennett", Password = "password43" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 44, Name = "Paula", Surname = "Carter", Mail = "paula.carter@example.com", TcNumber = "12345678944", Adress = "Main Street 45", PhoneNumber = "987654364", Username = "paulacarter", Password = "password44" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 45, Name = "Quincy", Surname = "Morgan", Mail = "quincy.morgan@example.com", TcNumber = "12345678945", Adress = "Main Street 46", PhoneNumber = "987654365", Username = "quincymorgan", Password = "password45" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 46, Name = "Rebecca", Surname = "Reed", Mail = "rebecca.reed@example.com", TcNumber = "12345678946", Adress = "Main Street 47", PhoneNumber = "987654366", Username = "rebeccareed", Password = "password46" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 47, Name = "Samuel", Surname = "Ward", Mail = "samuel.ward@example.com", TcNumber = "12345678947", Adress = "Main Street 48", PhoneNumber = "987654367", Username = "samuelward", Password = "password47" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 48, Name = "Tara", Surname = "James", Mail = "tara.james@example.com", TcNumber = "12345678948", Adress = "Main Street 49", PhoneNumber = "987654368", Username = "tarajames", Password = "password48" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 49, Name = "Uma", Surname = "Henderson", Mail = "uma.henderson@example.com", TcNumber = "12345678949", Adress = "Main Street 50", PhoneNumber = "987654369", Username = "umahenderson", Password = "password49" }
			);
			builder.Entity<Patient>().HasData(
				new Patient { Id = 50, Name = "Violet", Surname = "Brooks", Mail = "violet.brooks@example.com", TcNumber = "12345678950", Adress = "Main Street 51", PhoneNumber = "987654370", Username = "violetbrooks", Password = "password50" }
			);

			builder.Entity<Prescription>().HasData(
				new Prescription { Id = 1, MedicationName = "Aspirin", PrescriptionDate = new DateOnly(2023, 1, 1), Usage = "Twice a day", PatientId = 1, DoctorId = 1 }
			);
			builder.Entity<Prescription>().HasData(
				new Prescription { Id = 2, MedicationName = "Ibuprofen", PrescriptionDate = new DateOnly(2023, 2, 15), Usage = "Once a day", PatientId = 2, DoctorId = 2 }
			);
			builder.Entity<Prescription>().HasData(
				new Prescription { Id = 3, MedicationName = "Paracetamol", PrescriptionDate = new DateOnly(2023, 3, 10), Usage = "Three times a day", PatientId = 3, DoctorId = 3 }
			);
			builder.Entity<Prescription>().HasData(
				new Prescription { Id = 4, MedicationName = "Metformin", PrescriptionDate = new DateOnly(2023, 4, 5), Usage = "Twice a day", PatientId = 4, DoctorId = 4 }
			);
			builder.Entity<Prescription>().HasData(
				new Prescription { Id = 5, MedicationName = "Amoxicillin", PrescriptionDate = new DateOnly(2023, 5, 20), Usage = "Once a day", PatientId = 5, DoctorId = 5 }
			);
			builder.Entity<Prescription>().HasData(
				new Prescription { Id = 6, MedicationName = "Atorvastatin", PrescriptionDate = new DateOnly(2023, 6, 25), Usage = "Once a day", PatientId = 6, DoctorId = 6 }
			);
			builder.Entity<Prescription>().HasData(
				new Prescription { Id = 7, MedicationName = "Lisinopril", PrescriptionDate = new DateOnly(2023, 7, 30), Usage = "Twice a day", PatientId = 7, DoctorId = 7 }
			);
			builder.Entity<Prescription>().HasData(
				new Prescription { Id = 8, MedicationName = "Levothyroxine", PrescriptionDate = new DateOnly(2023, 8, 12), Usage = "Once a day", PatientId = 8, DoctorId = 8 }
			);
			builder.Entity<Prescription>().HasData(
				new Prescription { Id = 9, MedicationName = "Omeprazole", PrescriptionDate = new DateOnly(2023, 9, 18), Usage = "Once a day", PatientId = 9, DoctorId = 9 }
			);
			builder.Entity<Prescription>().HasData(
				new Prescription { Id = 10, MedicationName = "Simvastatin", PrescriptionDate = new DateOnly(2023, 10, 22), Usage = "Twice a day", PatientId = 10, DoctorId = 10 }
			);


			builder.Entity<Appointment>().HasData(
				new Appointment { Id = 1, DateTime = new DateTime(2023, 1, 1, 10, 0, 0), DoctorId = 1, PatientId = 1 }
			);
			builder.Entity<Appointment>().HasData(
				new Appointment { Id = 2, DateTime = new DateTime(2023, 1, 2, 11, 0, 0), DoctorId = 2, PatientId = 2 }
			);
			builder.Entity<Appointment>().HasData(
				new Appointment { Id = 3, DateTime = new DateTime(2023, 1, 3, 12, 0, 0), DoctorId = 3, PatientId = 3 }
			);
			builder.Entity<Appointment>().HasData(
				new Appointment { Id = 4, DateTime = new DateTime(2023, 1, 4, 13, 0, 0), DoctorId = 4, PatientId = 4 }
			);
			builder.Entity<Appointment>().HasData(
				new Appointment { Id = 5, DateTime = new DateTime(2023, 1, 5, 14, 0, 0), DoctorId = 5, PatientId = 5 }
			);
			builder.Entity<Appointment>().HasData(
				new Appointment { Id = 6, DateTime = new DateTime(2023, 1, 6, 15, 0, 0), DoctorId = 6, PatientId = 6 }
			);
			builder.Entity<Appointment>().HasData(
				new Appointment { Id = 7, DateTime = new DateTime(2023, 1, 7, 16, 0, 0), DoctorId = 7, PatientId = 7 }
			);
			builder.Entity<Appointment>().HasData(
				new Appointment { Id = 8, DateTime = new DateTime(2023, 1, 8, 17, 0, 0), DoctorId = 8, PatientId = 8 }
			);
			builder.Entity<Appointment>().HasData(
				new Appointment { Id = 9, DateTime = new DateTime(2023, 1, 9, 18, 0, 0), DoctorId = 9, PatientId = 9 }
			);
			builder.Entity<Appointment>().HasData(
				new Appointment { Id = 10, DateTime = new DateTime(2023, 1, 10, 19, 0, 0), DoctorId = 10, PatientId = 10 }
			);
		}
	}
}


