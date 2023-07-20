using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using doctor_appointment.Contracts.User;
using doctor_appointment.Application.Services.Users;

namespace doctor_appointment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("Doctors")]
        public async Task<IActionResult> GetAllDoctorsAsync()
        {
            var doctors = await _usersService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var response = await _usersService.RegisterAsync(request);
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var response = await _usersService.LoginAsync(request);
            return Ok(response);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            var response = await _usersService.LogoutAsync();
            return Ok(response);
        }
    }
}
