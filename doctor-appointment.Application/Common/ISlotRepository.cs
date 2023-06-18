using doctor_appointment.Domain.Entities;

namespace doctor_appointment.Application.Common;

public interface ISlotRepository
{
    void Add(Slot slot);
    Slot? GetSlotByDateTime(DateTime dt);
    List<Slot> GetAllSlots();
    List<Slot> GetAvailableSlots();
}