using doctor_appointment.Domain.Entities;

namespace doctor_appointment.Domain.IRepositories;

public interface IAppointmentRepository
{
    void AddAsync(Appointment appointment);
    void CompleteAppointmentAsync(Guid id);
    void CancelAppointmentAsync(Guid id);
    Task<List<Appointment>> GetAllAsync();
    Task<List<Appointment>> GetUpcomingAppointmentsAsync();
    Task<List<Appointment>> GetAppointmentsForPatientAsync(Guid id);
}