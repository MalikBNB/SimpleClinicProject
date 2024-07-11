using SimpleClinic.Data.Layers.Entities;
using SimpleClinic.Data.Layers.Migrations;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SimpleClinic.Data.Layers
{
    public class AppDbContext : DbContext
    {
        public static string ConnectionString = "Data Source=(local); Initial Catalog = SimpleClinicDb; MultipleActiveResultSets=True;;Integrated Security=True;";

        public AppDbContext() : this(ConnectionString) { }


        public AppDbContext(string ConnectionString) : base(ConnectionString)
        {
            Database.CreateIfNotExists();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
            //Database.Initialize(false);
        }


        public DbSet<Person> Persons { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasRequired(e => e.Patient).WithMany(o => o.Appointments)
                                              .HasForeignKey(o => o.PatientId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Appointment>().HasRequired(e => e.Doctor).WithMany(o => o.Appointments)
                                            .HasForeignKey(o => o.DoctorId).WillCascadeOnDelete(false);

            modelBuilder.Entity<User>().HasMany(o => o.CreatedUsers)
                                       .WithOptional(u => u.Creator).HasForeignKey(o => o.CreatorId);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
