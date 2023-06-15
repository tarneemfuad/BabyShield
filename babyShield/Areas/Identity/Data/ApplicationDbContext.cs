using babyShield.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace babyShield.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public ApplicationDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<Doctor> doctors { get; set; }
    public DbSet<Clinic> clinics { get; set; }
    public DbSet<DoctorAppointment> doctorAppointments { get; set; }
    public DbSet<Manager> managers { get; set; }
    public DbSet<Patient> patients { get; set; }
    public DbSet<Reception> receptions { get; set; }
    public DbSet<Admin> admins { get; set; }
    public DbSet<Vaccine> vaccines { get; set; }
    public DbSet<PatientVaccine> patientVaccines { get; set; }
    public DbSet<prescription> prescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Other configuration code...

        optionsBuilder.EnableSensitiveDataLogging();

        // Additional configuration code...
    }

}
