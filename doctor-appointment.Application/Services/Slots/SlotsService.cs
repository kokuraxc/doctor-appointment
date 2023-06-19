using doctor_appointment.Contracts.Slot;
using doctor_appointment.Domain.Entities;
using doctor_appointment.Domain.IRepositories;

namespace doctor_appointment.Application.Services.Slots;

public class SlotsService : ISlotsService
{
    private readonly ISlotRepository _slotsRepository;

    public SlotsService(ISlotRepository slotsRepository)
    {
        _slotsRepository = slotsRepository;
    }

    public async Task<CreateSlotResponse> CreateSlotAsync(CreateSlotRequest request)
    {
        if (await _slotsRepository.GetSlotByDateTimeAsync(request.StartDate) is not null)
        {
            throw new Exception("Slot already exists at " + request.StartDate.ToString());
        }

        var slot = new Slot
        {
            StartDate = request.StartDate,
            DoctorName = request.DoctorName,
            IsReserved = request.IsReserved,
            Cost = request.Cost
        };

        slot =  await _slotsRepository.AddAsync(slot);
        return new CreateSlotResponse(slot.Id, slot.StartDate, slot.DoctorName!, slot.IsReserved, slot.Cost);
    }

    public async Task<List<CreateSlotResponse>> GetAllSlotsAsync()
    {
        var slots = await _slotsRepository.GetAllSlotsAsync();
        return slots.Select(slot => new CreateSlotResponse(slot.Id, slot.StartDate, slot.DoctorName!, slot.IsReserved, slot.Cost)).ToList();
    }

    public async Task<List<CreateSlotResponse>> GetAvailableSlotsAsync()
    {
        var slots = await _slotsRepository.GetAvailableSlotsAsync();
        return slots.Select(slot => new CreateSlotResponse(slot.Id, slot.StartDate, slot.DoctorName!, slot.IsReserved, slot.Cost)).ToList();
    }
}