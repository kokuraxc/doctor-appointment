using doctor_appointment.Application;
using doctor_appointment.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddApplication()
        .AddInfrastructure(builder.Configuration.GetConnectionString("DbSQLite")!);
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