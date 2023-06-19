using doctor_appointment.Domain.Entities;
using doctor_appointment.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace doctor_appointment.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    public readonly DoctorAppointmentContext _dbContext;
    public PatientRepository(DoctorAppointmentContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Patient> AddAsync(Patient patient)
    {
        await _dbContext.AddAsync(patient);
        await _dbContext.SaveChangesAsync();
        return patient;
    }

    public async Task<List<Patient>> GetAllAsync()
    {
        return await _dbContext.Patients.ToListAsync();
    }
}