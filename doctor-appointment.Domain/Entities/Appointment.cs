namespace doctor_appointment.Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SlotId { get; set; } = default!;
    public Guid PatientId { get; set; } = default!;
    public string PatientName { get; set; } = default!;
    public DateTime ReservedAt { get; set; } = default!;
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Confirmed;

    public void CancelAppointment()
    {
        this.Status = AppointmentStatus.Cancelled;
    }

    public void CompleteAppointment()
    {
        this.Status = AppointmentStatus.Completed;
    }
    
}

public enum AppointmentStatus
{
    Confirmed = 1,
    Cancelled = 2,
    Completed = 3
}