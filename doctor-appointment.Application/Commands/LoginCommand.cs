using doctor_appointment.Application.Common;
using doctor_appointment.Contracts.User;
using MediatR;

namespace doctor_appointment.Application.Commands;

public record LoginCommand(
    string Username,
    string Password
) : IRequest<LoginResponse>;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResponse> Handle(
        LoginCommand command,
        CancellationToken cancellationToken)
    {
        // check if username and password are correct

        // generate jwt token
        Guid guid = Guid.NewGuid();
        string firstName = "first name";
        string lastName = "last name";
        string role = "Doctor";
        var token = _jwtTokenGenerator.GenerateToken(
            guid,
            firstName,
            lastName,
            role);

        var response = new LoginResponse(
            Username: command.Username,
            FirstName: firstName,
            LastName: lastName,
            Role: role,
            Token: token);
        return response;
    }
}