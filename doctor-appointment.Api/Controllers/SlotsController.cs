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
    public IActionResult GetAllSlots()
    {
        var slots = _slotsService.GetAllSlots();
        var response = slots.Select(slot => new CreateSlotResponse(
            slot.Id,
            slot.StartDate,
            slot.DoctorName,
            slot.IsReserved,
            slot.Cost
        ));

        return Ok(response);
    }

    [Route("available")]
    [HttpGet]
    public IActionResult GetAvailableSlots()
    {
        var slots = _slotsService.GetAvailableSlots();
        var response = slots.Select(slot => new CreateSlotResponse(
            slot.Id,
            slot.StartDate,
            slot.DoctorName,
            slot.IsReserved,
            slot.Cost
        ));

        return Ok(response);
    }

    [HttpPost]
    public IActionResult CreateSlot(CreateSlotRequest request)
    {
        var slot = _slotsService.CreateSlot(request.StartDate, request.DoctorName, request.IsReserved, request.Cost);
        var response = new CreateSlotResponse(slot.Id, slot.StartDate, slot.DoctorName, slot.IsReserved, slot.Cost);
        return Ok(response);
    }
}