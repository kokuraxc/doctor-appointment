namespace doctor_appointment.Domain.Exceptions;

public class AppointmentNotExistsException : Exception
{
    public AppointmentNotExistsException(string message) : base(message) { }
}