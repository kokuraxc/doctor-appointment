using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using doctor_appointment.Contracts.User;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MediatR;
using doctor_appointment.Application.Commands;

namespace doctor_appointment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("Doctors")]
        public async Task<IActionResult> GetAllDoctorsAsync()
        {
            var command = new GetAllDoctorsCommand();
            var result = await _mediator.Send(command);
            return Ok(result);

            var role = User.Claims.Where(c => c.Type.Contains("role")).Select(c => c.Value).FirstOrDefault();
            _logger.LogInformation("Role is {UserRole}", role);
            foreach (var claim in User.Claims)
            {
                _logger.LogInformation(claim.Type);
                _logger.LogInformation(claim.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var command = new RegisterCommand(request.Username, request.Password, request.FirstName, request.LastName, request.Role);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var command = new LoginCommand(request.Username, request.Password);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
