using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using doctor_appointment.Application.Services.Slots;
using doctor_appointment.Application.Services.Patients;
using doctor_appointment.Application.Services.Appointments;
using doctor_appointment.Application.Services.Users;
using doctor_appointment.Application.Common;

namespace doctor_appointment.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddScoped<ISlotsService, SlotsService>();
        services.AddScoped<IPatientsService, PatientsService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}