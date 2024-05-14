using Microsoft.EntityFrameworkCore;
using Hospital_DAL.Entities;

namespace Hospital_DAL.EF
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options)
        {
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<OtherStaff> OtherStaffs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientVisit> PatientVisits { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DoctorPatient>().HasKey(dp => new { dp.DoctorID, dp.PatientID });

            modelBuilder.Entity<DoctorPatient>()
                .HasOne(dp => dp.Doctor)
                .WithMany(d => d.DoctorPatients)
                .HasForeignKey(dp => dp.DoctorID);

            modelBuilder.Entity<DoctorPatient>()
                .HasOne(dp => dp.Patient)
                .WithMany(p => p.DoctorPatients)
                .HasForeignKey(dp => dp.PatientID);

            modelBuilder.Entity<Login>()
                .HasKey(l => l.LoginID);
            modelBuilder.Entity<Login>()
                .HasIndex(l => l.Email).IsUnique();

            modelBuilder.Entity<Person>()
                .HasKey(p => p.ID);
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Login)
                .WithOne()
                .HasForeignKey<Person>(p => p.ID);

            modelBuilder.Entity<Department>()
                .HasKey(d => d.DeptNo);
            modelBuilder.Entity<Department>()
                .HasIndex(d => d.DeptName).IsUnique();

            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.DoctorID);
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Department)
                .WithMany()
                .HasForeignKey(d => d.DeptNo)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Person)
                .WithOne()
                .HasForeignKey<Doctor>(d => d.PersonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OtherStaff>()
                .HasKey(os => os.StaffID);
            modelBuilder.Entity<OtherStaff>()
                .HasOne(os => os.Person)
                .WithOne()
                .HasForeignKey<OtherStaff>(os => os.PersonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasKey(p => p.PatientID);
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Person)
                .WithOne()
                .HasForeignKey<Patient>(p => p.PersonID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PatientVisit>()
                .HasKey(pv => pv.ID);
            modelBuilder.Entity<PatientVisit>()
                .HasOne(pv => pv.Doctor)
                .WithMany()
                .HasForeignKey(pv => pv.DoctorID)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<PatientVisit>()
                .HasOne(pv => pv.Patient)
                .WithMany()
                .HasForeignKey(pv => pv.PatientID);

            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.AppointID);
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.PatientVisit)
                .WithOne()
                .HasForeignKey<Appointment>(a => a.VisitID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
