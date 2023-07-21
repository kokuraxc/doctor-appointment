using doctor_appointment.Contracts.User;
using MediatR;

namespace doctor_appointment.Application.Commands;

public record RegisterCommand
    (
        string Username,
        string Password,
        string FirstName,
        string LastName,
        UserRole Role
    ) : IRequest<RegisterResponse>;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    public async Task<RegisterResponse> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        // check if user already exists

        // create user

        var response = new RegisterResponse(
                Id: Guid.NewGuid(),
                Username: command.Username,
                Password: command.Password,
                FirstName: command.FirstName,
                LastName: command.LastName,
                Role: command.Role.ToString()
            );

        return response;
    }
}