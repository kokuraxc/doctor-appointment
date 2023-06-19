using doctor_appointment.Domain.IRepositories;
using doctor_appointment.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace doctor_appointment.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ISlotRepository, SlotRepository>();
        return services;
    }
}