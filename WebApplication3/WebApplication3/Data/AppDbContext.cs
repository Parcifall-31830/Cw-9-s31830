using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data;

public class AppDbContext : DbContext
{
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments{ get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var medicament1 = new Medicament()
        {
            IdMedicament = 1,
            Name = "Paracetamol",
            Description = "Pain reliever and fever reducer",
            Type = "Tablet"
        };
        var medicament2 = new Medicament()
        {
            IdMedicament = 2,
            Name = "Amoxicillin",
            Description = "Antibiotic",
            Type = "Capsule"
        };

        var doctor1 = new Doctor()
        {
            IdDoctor = 1,
            FirstName = "Anna",
            LastName = "Kowalska",
            Email = "anna.kowalska@gmail.com"
        };
        var doctor2 = new Doctor()
        {
            IdDoctor = 2,
            FirstName = "Piotr",
            LastName = "Nowak",
            Email = "piotr.nowak@gmail.com"
        };
        var patient1 = new Patient()
        {
            IdPatient = 1,
            FirstName = "Jan",
            LastName = "Kowalski",
            Birthdate = DateTime.Parse("1990-03-15"),
        };
        var patient2 = new Patient()
        {
            IdPatient = 2,
            FirstName = "Maria",
            LastName = "Wisniewska",
            Birthdate = DateTime.Parse("1985-07-20"),
        };
        var prescription1 = new Prescription()
        {
            IdPrescription = 1,
            Date = DateTime.Parse("2025-05-01"),
            DueDate = DateTime.Parse("2025-05-15"),
            IdPatient = 1,
            IdDoctor = 1
        };
        var prescription2 = new Prescription()
        {
            IdPrescription = 2,
            Date = DateTime.Parse("2025-05-05"),
            DueDate = DateTime.Parse("2025-05-20"),
            IdPatient = 2,
            IdDoctor = 2
        };
        var prescriptionMedicament1 = new PrescriptionMedicament()
        {
            IdMedicament = 1,
            IdPrescription = 1,
            Dose = 500,
            Details = "Take 2 times daily"
        };
        var prescriptionMedicament2 = new PrescriptionMedicament()
        {
            IdMedicament = 2,
            IdPrescription = 1,
            Dose = 250,
            Details = "Take after meals"
        };
        var prescriptionMedicament3 = new PrescriptionMedicament()
        {
            IdMedicament = 1,
            IdPrescription = 2,
            Dose = 500,
            Details = "Morning and Evening"
        };
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Medicament>().HasData(medicament1, medicament2);

        modelBuilder.Entity<Doctor>().HasData(doctor1, doctor2);

        modelBuilder.Entity<Patient>().HasData(patient1, patient2);

        modelBuilder.Entity<Prescription>().HasData(prescription1, prescription2);

        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            prescriptionMedicament1,
            prescriptionMedicament2,
            prescriptionMedicament3
        );

    }
}