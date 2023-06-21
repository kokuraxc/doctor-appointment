using doctor_appointment.Contracts.Appointment;
using doctor_appointment.Domain.Entities;

namespace doctor_appointment.Application.Services.Appointments;

public interface IAppointmentService
{
    // Task<CreateAppointmentResponse> CreateAppointmentAsync(CreateAppointmentRequest request);
    // Task<List<CreateAppointmentResponse>> GetAllAsync();
    // Task<List<CreateAppointmentResponse>> GetUpcomingAppointmentsAsync();
    // Task<List<CreateAppointmentResponse>> GetAppointmentsForPatientAsync(Guid patientId);
    Task<CreateAppointmentResponse> UpdateAppointmentAsync(Guid appointmentId, AppointmentStatus newStatus);
}