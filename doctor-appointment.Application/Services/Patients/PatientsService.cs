using doctor_appointment.Contracts.Patient;
using doctor_appointment.Domain.Entities;
using doctor_appointment.Domain.IRepositories;

namespace doctor_appointment.Application.Services.Patients;

public class PatientsService : IPatientsService
{
    private readonly IPatientRepository _patientRepository;

    public PatientsService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<CreatePatientResponse> CreatePatientAsync(CreatePatientRequest request)
    {
        Patient patient = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName
        };
        patient = await _patientRepository.AddAsync(patient);
        return new CreatePatientResponse(patient.Id, patient.FirstName, patient.LastName);
    }

    public async Task<List<CreatePatientResponse>> GetAllAsync()
    {
        var patients = await _patientRepository.GetAllAsync();
        return patients.Select(patient => new CreatePatientResponse(patient.Id, patient.FirstName, patient.LastName)).ToList();
    }
}