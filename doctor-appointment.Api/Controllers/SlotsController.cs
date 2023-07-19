using doctor_appointment.Application.Services.Slots;
using doctor_appointment.Contracts.Slot;
using Microsoft.AspNetCore.Mvc;

namespace doctor_appointment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class SlotsController : ControllerBase
{
    private readonly ISlotsService _slotsService;
    private readonly ILogger<SlotsController> _logger;

    public SlotsController(ISlotsService slotsService, ILogger<SlotsController> logger)
    {
        _slotsService = slotsService;
        _logger = logger;
    }

    [Route("")]
    [HttpGet]
    public async Task<IActionResult> GetAllSlotsAsync()
    {
        _logger.LogInformation("Requesting all slots");
        var slots = await _slotsService.GetAllSlotsAsync();
        return Ok(slots);
    }

    [Route("available")]
    [HttpGet]
    public async Task<IActionResult> GetAvailableSlotsAsync()
    {
        _logger.LogInformation("Requesting available slots");
        var slots = await _slotsService.GetAvailableSlotsAsync();
        return Ok(slots);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSlotAsync(CreateSlotRequest request)
    {
        _logger.LogInformation("Create new slot {request}", request);
        var slot = await _slotsService.CreateSlotAsync(request);
        return Ok(slot);
    }
}