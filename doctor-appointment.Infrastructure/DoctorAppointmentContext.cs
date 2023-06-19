using doctor_appointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace doctor_appointment.Infrastructure;

public class DoctorAppointmentContext : DbContext
{
    public DoctorAppointmentContext(DbContextOptions<DoctorAppointmentContext> options) : base(options) { }

    public DbSet<Slot> Slots { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Slot>().ToTable("Slots");
    }
}