using doctor_appointment.Contracts.User;

namespace doctor_appointment.Application.Services.Users;

public interface IUsersService
{
    Task<List<GetDoctorResponse>> GetAllDoctorsAsync();
    Task<RegisterResponse> RegisterAsync(RegisterRequest request);
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task<bool> LogoutAsync();
}