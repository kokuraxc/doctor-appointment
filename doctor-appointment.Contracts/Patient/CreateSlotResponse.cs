namespace doctor_appointment.Contracts.Patient;
public record CreatePatientResponse(
    Guid Id,
    string FirstName,
    string LastName
);