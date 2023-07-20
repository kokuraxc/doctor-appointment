using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using doctor_appointment.Contracts.User;

namespace doctor_appointment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet("Doctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            return Ok("user 1; user 2; user 3");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = new RegisterResponse(
                Id: Guid.NewGuid(),
                Username: request.Username,
                Password: request.Password,
                FirstName: request.FirstName,
                LastName: request.LastName,
                Role: request.Role
            );

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {
            var response = new LoginResponse(
                Token: "jwt token");
            return Ok(response);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok("logout successfully.");
        }
    }
}
