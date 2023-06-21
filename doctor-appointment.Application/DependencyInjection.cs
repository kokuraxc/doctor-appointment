using Microsoft.Extensions.DependencyInjection;
using doctor_appointment.Application.Services.Slots;
using doctor_appointment.Application.Services.Patients;
using doctor_appointment.Application.Services.Appointments;

namespace doctor_appointment.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ISlotsService, SlotsService>();
        services.AddScoped<IPatientsService, PatientsService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        return services;
    }
}