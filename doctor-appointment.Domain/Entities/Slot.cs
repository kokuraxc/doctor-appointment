namespace doctor_appointment.Domain.Entities;

public class Slot
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime StartDate { get; set; }
    public string? DoctorName { get; set; }
    public bool IsReserved { get; set; }
    public Decimal Cost { get; set; }
}