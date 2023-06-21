namespace doctor_appointment.Contracts.Appointment;

public record CreateAppointmentResponse(
    Guid Id,
    Guid SlotId,
    Guid PatientId,
    string PatientName,
    DateTime ReserveAt,
    string Status
);