using doctor_appointment.Domain.Entities;

namespace doctor_appointment.Domain.IRepositories;

public interface IAppointmentRepository
{
    Task<Appointment> AddAsync(Guid slotId, Guid patientId);
    Task<Appointment> CompleteAppointmentAsync(Guid id);
    Task<Appointment> CancelAppointmentAsync(Guid id);
    Task<List<Appointment>> GetAllAsync();
    Task<List<Appointment>> GetUpcomingAppointmentsAsync();
    Task<List<Appointment>> GetAppointmentsForPatientAsync(Guid id);
}