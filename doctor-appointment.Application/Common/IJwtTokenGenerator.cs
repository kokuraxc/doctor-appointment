namespace doctor_appointment.Application.Common;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid id, string firstName, string lastName, string role);
}