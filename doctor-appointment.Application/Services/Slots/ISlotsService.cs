using doctor_appointment.Contracts.Slot;

namespace doctor_appointment.Application.Services.Slots;

public interface ISlotsService
{
    Task<CreateSlotResponse> CreateSlotAsync(CreateSlotRequest request);
    Task<List<CreateSlotResponse>> GetAllSlotsAsync();
    Task<List<CreateSlotResponse>> GetAvailableSlotsAsync();
}