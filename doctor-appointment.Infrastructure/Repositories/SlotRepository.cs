using doctor_appointment.Domain.Entities;
using doctor_appointment.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace doctor_appointment.Infrastructure.Repositories;

public class SlotRepository : ISlotRepository
{
    public readonly DoctorAppointmentContext _dbContext;

    public SlotRepository(DoctorAppointmentContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Slot> AddAsync(Slot slot)
    {
        await _dbContext.Slots.AddAsync(slot);
        await _dbContext.SaveChangesAsync();
        return slot;
    }

    public async Task<List<Slot>> GetAllSlotsAsync()
    {
        return await _dbContext.Slots.ToListAsync();
    }

    public async Task<List<Slot>> GetAvailableSlotsAsync()
    {
        return await _dbContext.Slots.Where(s => !s.IsReserved).ToListAsync();
    }

    public async Task<Slot?> GetSlotByDateTimeAsync(DateTime dt)
    {
        return await _dbContext.Slots.FirstOrDefaultAsync(s => s.StartDate == dt);
    }
}