namespace doctor_appointment.Contracts.Appointment;

public record CreateAppointmentRequest(
    Guid SlotId,
    Guid PatientId,
    string PatientName,
    DateTime ReserveAt
);