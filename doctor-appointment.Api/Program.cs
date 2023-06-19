using doctor_appointment.Application;
using doctor_appointment.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddApplication()
        .AddInfrastructure();
    builder.Services.AddControllers();
}

var app = builder.Build();

{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}