using doctor_appointment.Domain.Entities;

namespace doctor_appointment.Domain.IRepositories;

public interface ISlotRepository
{
    Task<Slot> AddAsync(Slot slot);
    Task<Slot?> GetSlotByDateTimeAsync(DateTime dt);
    Task<List<Slot>> GetAllSlotsAsync();
    Task<List<Slot>> GetAvailableSlotsAsync();
}