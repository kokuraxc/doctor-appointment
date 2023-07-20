using doctor_appointment.Application.Services.Patients;
using doctor_appointment.Contracts.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace doctor_appointment.Api.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientsService _patientService;

    public PatientsController(IPatientsService patientService)
    {
        _patientService = patientService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient(CreatePatientRequest request){
        var response = await _patientService.CreatePatientAsync(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetPatients(){
        var response = await _patientService.GetAllAsync();
        return Ok(response);
    }
}