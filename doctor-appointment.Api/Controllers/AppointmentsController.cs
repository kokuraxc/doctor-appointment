using System.Diagnostics.Contracts;
using doctor_appointment.Application.Services.Appointments;
using doctor_appointment.Contracts.Appointment;
using doctor_appointment.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace doctor_appointment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentsService;
    private readonly IAppointmentRepository _appointmentsRepository;

    public AppointmentsController(IAppointmentRepository appointmentsRepository, IAppointmentService appointmentsService)
    {
        _appointmentsRepository = appointmentsRepository;
        _appointmentsService = appointmentsService;
    }

    private CreateAppointmentResponse MapToResponse(Domain.Entities.Appointment appointment)
    {
        return new CreateAppointmentResponse(
            appointment.Id,
            appointment.SlotId,
            appointment.PatientId,
            appointment.PatientName,
            appointment.ReservedAt,
            appointment.Status.ToString());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointmentAsync(CreateAppointmentRequest request)
    {
        // var appointment = new Domain.Entities.Appointment
        // {
        //     SlotId = request.SlotId,
        //     PatientId = request.PatientId,
        //     PatientName = request.PatientName,
        //     ReservedAt = request.ReservedAt
        // };
        var appointment = await _appointmentsRepository.AddAsync(request.SlotId, request.PatientId);

        return Ok(MapToResponse(appointment));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAppointmentAsync()
    {
        var appointments = await _appointmentsRepository.GetAllAsync();
        return Ok(appointments.Select(MapToResponse));
    }

    [HttpGet("doctor")]
    public async Task<IActionResult> GetUpcomingAppointmentAsync()
    {
        var appointments = await _appointmentsRepository.GetUpcomingAppointmentsAsync();
        return Ok(appointments.Select(MapToResponse));
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetUpcomingAppointmentAsync(Guid patientId)
    {
        var appointments = await _appointmentsRepository.GetAppointmentsForPatientAsync(patientId);
        return Ok(appointments.Select(MapToResponse));
    }

    [HttpPost("{appointmentId}/Complete")]
    public async Task<IActionResult> CompleteAppointmentAsync(Guid appointmentId)
    {
        var response = await _appointmentsService.UpdateAppointmentAsync(appointmentId, Domain.Entities.AppointmentStatus.Completed);
        return Ok(response);
    }

    [HttpPost("{appointmentId}/Cancel")]
    public async Task<IActionResult> CancelAppointmentAsync(Guid appointmentId)
    {
        var response = await _appointmentsService.UpdateAppointmentAsync(appointmentId, Domain.Entities.AppointmentStatus.Cancelled);
        return Ok(response);
    }
}