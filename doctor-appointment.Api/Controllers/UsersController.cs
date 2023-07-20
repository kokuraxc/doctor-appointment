using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using doctor_appointment.Contracts.User;
using doctor_appointment.Application.Services.Users;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace doctor_appointment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUsersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("Doctors")]
        public async Task<IActionResult> GetAllDoctorsAsync()
        {
            var role = User.Claims.Where(c => c.Type.Contains( "role")).Select(c => c.Value).FirstOrDefault();
            _logger.LogInformation("Role is {UserRole}", role);
            foreach (var claim in User.Claims)
            {
                _logger.LogInformation(claim.Type);
                _logger.LogInformation(claim.ToString());
            }

            //_logger.LogInformation(User.Identity.);

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
