using doctor_appointment.Application.Services.Slots;
using doctor_appointment.Contracts.Slot;
using Microsoft.AspNetCore.Mvc;

namespace doctor_appointment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class SlotsController : ControllerBase
{
    private readonly ISlotsService _slotsService;

    public SlotsController(ISlotsService slotsService)
    {
        _slotsService = slotsService;
    }

    [Route("")]
    [HttpGet]
    public async Task<IActionResult> GetAllSlotsAsync()
    {
        var slots = await _slotsService.GetAllSlotsAsync();
        return Ok(slots);
    }

    [Route("available")]
    [HttpGet]
    public async Task<IActionResult> GetAvailableSlotsAsync()
    {
        var slots = await _slotsService.GetAvailableSlotsAsync();
        return Ok(slots);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSlotAsync(CreateSlotRequest request)
    {
        var slot = await _slotsService.CreateSlotAsync(request);
        return Ok(slot);
    }
}