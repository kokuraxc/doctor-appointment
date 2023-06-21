using doctor_appointment.Contracts.Appointment;
using doctor_appointment.Domain.Entities;
using doctor_appointment.Domain.IRepositories;

namespace doctor_appointment.Application.Services.Appointments;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<CreateAppointmentResponse> UpdateAppointmentAsync(Guid appointmentId, AppointmentStatus newStatus)
    {
        Appointment appointment;
        if (newStatus == AppointmentStatus.Cancelled)
            appointment = await _appointmentRepository.CancelAppointmentAsync(appointmentId);
        else if (newStatus == AppointmentStatus.Completed)
            appointment = await _appointmentRepository.CompleteAppointmentAsync(appointmentId);
        else
            throw new ArgumentOutOfRangeException(nameof(newStatus));

        return new CreateAppointmentResponse(appointment.Id, appointment.SlotId, appointment.PatientId, appointment.PatientName, appointment.ReservedAt, appointment.Status.ToString());
    }
}