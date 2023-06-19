using doctor_appointment.Contracts.Patient;

namespace doctor_appointment.Application.Services.Patients;

public interface IPatientsService {
    Task<CreatePatientResponse> CreatePatientAsync(CreatePatientRequest request);
    Task<List<CreatePatientResponse>> GetAllAsync();
}