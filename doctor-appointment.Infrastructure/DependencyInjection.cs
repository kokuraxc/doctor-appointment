using doctor_appointment.Domain.IRepositories;
using doctor_appointment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace doctor_appointment.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DoctorAppointmentContext>(options => options.UseSqlite(connectionString));
        services.AddScoped<ISlotRepository, SlotRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        return services;
    }
}