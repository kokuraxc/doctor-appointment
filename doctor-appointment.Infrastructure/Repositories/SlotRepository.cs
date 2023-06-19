using doctor_appointment.Domain.Entities;
using doctor_appointment.Domain.IRepositories;

namespace doctor_appointment.Infrastructure.Repositories;

public class SlotRepository : ISlotRepository
{
    public readonly DoctorAppointmentContext _dbContext;

    public SlotRepository(DoctorAppointmentContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Slot slot)
    {
        _dbContext.Slots.Add(slot);
        _dbContext.SaveChanges();
    }

    public List<Slot> GetAllSlots()
    {
        return _dbContext.Slots.ToList();
    }

    public List<Slot> GetAvailableSlots()
    {
        return _dbContext.Slots.Where(s => !s.IsReserved).ToList();
    }

    public Slot? GetSlotByDateTime(DateTime dt)
    {
        return _dbContext.Slots.FirstOrDefault(s => s.StartDate == dt);
    }
}