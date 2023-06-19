namespace doctor_appointment.Domain.Entities;

public class Slot
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime StartDate { get; set; }
    public string? DoctorName { get; set; }
    public bool IsReserved { get; set; }
    public decimal Cost { get; set; }

    public void BookSlot(){
        this.IsReserved = true;
    }

    public void CancelBooking(){
        this.IsReserved = false;
    }
}