using Microsoft.Extensions.DependencyInjection;
using doctor_appointment.Application.Services.Slots;

namespace doctor_appointment.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ISlotsService, SlotsService>();

        return services;
    }
}