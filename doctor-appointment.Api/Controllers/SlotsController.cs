using doctor_appointment.Contracts.Slot;
using Microsoft.AspNetCore.Mvc;

namespace doctor_appointment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class SlotsController : ControllerBase
{
    [Route("")]
    [HttpGet]
    public IActionResult GetAllSlots()
    {
        return Ok();
    }

    [Route("available")]
    [HttpGet]
    public IActionResult GetAvailableSlots()
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateSlot(CreateSlotRequest request)
    {
        Console.WriteLine(request.StartDate.ToLongDateString());
        return Ok(request);
    }
}