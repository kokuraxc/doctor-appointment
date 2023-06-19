namespace doctor_appointment.Contracts.Patient;
public record CreatePatientRequest(
    string FirstName, string LastName
);