using doctor_appointment.Application;
using doctor_appointment.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

    builder.Services.AddApplication(builder.Configuration)
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
}

var app = builder.Build();

{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<DoctorAppointmentContext>();
        context.Database.EnsureCreated();
    }

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}