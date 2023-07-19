namespace doctor_appointment.Domain.Entities;

public class Patient {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();
}