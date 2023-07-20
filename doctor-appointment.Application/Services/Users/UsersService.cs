using doctor_appointment.Application.Common;
using doctor_appointment.Contracts.User;

namespace doctor_appointment.Application.Services.Users;

public class UsersService : IUsersService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public UsersService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        // check if user already exists

        // create user

        var response = new RegisterResponse(
                Id: Guid.NewGuid(),
                Username: request.Username,
                Password: request.Password,
                FirstName: request.FirstName,
                LastName: request.LastName,
                Role: request.Role
            );

        return response;
    }

    public async Task<List<GetDoctorResponse>> GetAllDoctorsAsync()
    {
        var doctors = new List<GetDoctorResponse>
        {
            new GetDoctorResponse(Id: Guid.NewGuid(),
                                  FirstName: "first 1",
                                  LastName: "last 1"),
        new GetDoctorResponse(Id: Guid.NewGuid(),
                            FirstName: "first 2",
                            LastName: "last 2")
        };

        return doctors;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        // check if username and password are correct

        // generate jwt token
        Guid guid = Guid.NewGuid();
        string firstName = "first name";
        string lastName = "last name";
        string role = "Doctor";
        var token = _jwtTokenGenerator.GenerateToken(guid, firstName, lastName, role);

        var response = new LoginResponse(
                Token: token);
        return response;
    }
}