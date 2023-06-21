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
        if(string.IsNullOrEmpty(patient.FirstName) && string.IsNullOrEmpty(patient.LastName)){
            throw new ArgumentException("Both firstName and lastName cannot be null or empty at the same time.");
        }
        if(await _dbContext.Patients.AnyAsync(p=>p.FirstName==patient.FirstName && p.LastName==patient.LastName)){
            throw new Exception("Patient already exists");
        }
        await _dbContext.Patients.AddAsync(patient);
        await _dbContext.SaveChangesAsync();
        return patient;
    }

    public async Task<List<Patient>> GetAllAsync()
    {
        return await _dbContext.Patients.ToListAsync();
    }
}