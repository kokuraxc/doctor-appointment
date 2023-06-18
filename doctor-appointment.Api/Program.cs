using doctor_appointment.Application.Services.Slots;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddScoped<ISlotsService, SlotsService>();
    builder.Services.AddControllers();
}

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}