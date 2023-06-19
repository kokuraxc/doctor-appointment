using doctor_appointment.Domain.Entities;

namespace doctor_appointment.Domain.IRepositories;

public interface IPatientRepository
{
    Task<Patient> AddAsync(Patient patient);
    Task<List<Patient>> GetAllAsync();
}