using doctor_appointment.Application.Common;
using doctor_appointment.Domain.Entities;

namespace doctor_appointment.Application.Services.Slots;

public class SlotsService : ISlotsService
{
    private readonly ISlotRepository _slotsRepository;

    public SlotsService(ISlotRepository slotsRepository)
    {
        _slotsRepository = slotsRepository;
    }

    public CreateSlotResult CreateSlot(DateTime startDate, string doctorName, bool isReserved, decimal cost)
    {
        if (_slotsRepository.GetSlotByDateTime(startDate) is not null)
        {
            throw new Exception("Slot already exists at {dateTime}");
        }

        var slot = new Slot
        {
            StartDate = startDate,
            DoctorName = doctorName,
            IsReserved = isReserved,
            Cost = cost
        };

        _slotsRepository.Add(slot);

        return new CreateSlotResult(slot);
    }

    public List<CreateSlotResult> GetAllSlots()
    {
        var slots = _slotsRepository.GetAllSlots();
        return slots.Select(s => new CreateSlotResult(s)).ToList();
    }

    public List<CreateSlotResult> GetAvailableSlots()
    {
        var slots = _slotsRepository.GetAvailableSlots();
        return slots.Select(s => new CreateSlotResult(s)).ToList();
    }
}