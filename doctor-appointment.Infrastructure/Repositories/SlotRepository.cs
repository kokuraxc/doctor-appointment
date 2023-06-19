using doctor_appointment.Domain.Entities;
using doctor_appointment.Domain.IRepositories;

namespace doctor_appointment.Infrastructure.Repositories;

public class SlotRepository : ISlotRepository
{
    public static readonly List<Slot> _slots = new();

    public void Add(Slot slot)
    {
        _slots.Add(slot);
    }

    public List<Slot> GetAllSlots()
    {
        return _slots;
    }

    public List<Slot> GetAvailableSlots()
    {
        return _slots.FindAll(slot => slot.IsReserved == false);
    }

    public Slot? GetSlotByDateTime(DateTime dt)
    {
        return _slots.SingleOrDefault(slot => slot.StartDate == dt);
    }
}