using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using doctor_appointment.Application.Services.Slots;
using doctor_appointment.Application.Services.Patients;
using doctor_appointment.Application.Services.Appointments;
using doctor_appointment.Application.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using MediatR;
using System.Reflection;

namespace doctor_appointment.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuth(configuration);
        services.AddScoped<ISlotsService, SlotsService>();
        services.AddScoped<IPatientsService, PatientsService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        // services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidIssuer = jwtSettings.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        });

        return services;
    }
}