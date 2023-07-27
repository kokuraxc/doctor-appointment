namespace doctor_appointment.Contracts.User;

public record GetDoctorResponse(
    Guid Id,
    string FirstName,
    string LastName
);