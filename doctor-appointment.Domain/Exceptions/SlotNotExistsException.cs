namespace doctor_appointment.Domain.Exceptions;

public class SlotNotExistsException : Exception
{
    public SlotNotExistsException(string message) : base(message) { }
}