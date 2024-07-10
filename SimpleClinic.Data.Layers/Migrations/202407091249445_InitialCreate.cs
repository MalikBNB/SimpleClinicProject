namespace SimpleClinic.Data.Layers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        MedicalRecordId = c.Int(),
                        AppointmentDate = c.DateTime(nullable: false),
                        AppointmentStatus = c.Boolean(nullable: false),
                        PaymentId = c.Int(),
                        CreatorId = c.Int(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecordId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .ForeignKey("dbo.Payments", t => t.PaymentId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.MedicalRecordId)
                .Index(t => t.PaymentId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 1000),
                        Password = c.String(),
                        CreatorId = c.Int(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .Index(t => t.Username, unique: true)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(),
                        Specialization = c.String(),
                        CreatorId = c.Int(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gendor = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        CreatorId = c.Int(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitDescription = c.String(),
                        Diagnosis = c.String(),
                        AdditionalNotes = c.String(),
                        CreatorId = c.Int(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        CreatorId = c.Int(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentMethod = c.Int(nullable: false),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdditionalNotes = c.String(),
                        CreatorId = c.Int(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicationName = c.String(),
                        MedicalRecordId = c.Int(),
                        Dosage = c.String(),
                        Frequency = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        SpecialInstructions = c.String(),
                        CreatorId = c.Int(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecordId)
                .Index(t => t.MedicalRecordId)
                .Index(t => t.CreatorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.Prescriptions", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Payments", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "PersonId", "dbo.People");
            DropForeignKey("dbo.Patients", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.MedicalRecords", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Doctors", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Users", "CreatorId", "dbo.Users");
            DropIndex("dbo.Prescriptions", new[] { "CreatorId" });
            DropIndex("dbo.Prescriptions", new[] { "MedicalRecordId" });
            DropIndex("dbo.Payments", new[] { "CreatorId" });
            DropIndex("dbo.Patients", new[] { "CreatorId" });
            DropIndex("dbo.Patients", new[] { "PersonId" });
            DropIndex("dbo.MedicalRecords", new[] { "CreatorId" });
            DropIndex("dbo.People", new[] { "CreatorId" });
            DropIndex("dbo.Doctors", new[] { "CreatorId" });
            DropIndex("dbo.Doctors", new[] { "PersonId" });
            DropIndex("dbo.Users", new[] { "CreatorId" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Appointments", new[] { "CreatorId" });
            DropIndex("dbo.Appointments", new[] { "PaymentId" });
            DropIndex("dbo.Appointments", new[] { "MedicalRecordId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Payments");
            DropTable("dbo.Patients");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.People");
            DropTable("dbo.Doctors");
            DropTable("dbo.Users");
            DropTable("dbo.Appointments");
        }
    }
}
