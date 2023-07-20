using doctor_appointment.Contracts.User;

namespace doctor_appointment.Application.Services.Users;

public class UsersService : IUsersService
{
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
        var response = new LoginResponse(
                Token: "jwt token");
        return response;
    }

    public async Task<bool> LogoutAsync()
    {
        return true;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
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
}