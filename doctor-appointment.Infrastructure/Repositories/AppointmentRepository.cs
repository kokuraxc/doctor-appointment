using doctor_appointment.Domain.Entities;
using doctor_appointment.Domain.Exceptions;
using doctor_appointment.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace doctor_appointment.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    public readonly DoctorAppointmentContext _dbContext;

    public AppointmentRepository(DoctorAppointmentContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async void AddAsync(Appointment appointment)
    {
        await _dbContext.Appointments.AddAsync(appointment);
        await _dbContext.SaveChangesAsync();
    }

    public async void CancelAppointmentAsync(Guid id)
    {
        var appointment = await _dbContext.Appointments.FindAsync(id)
            ?? throw new AppointmentNotExistsException("Appointment not exists for Id " + id);
        var slot = await _dbContext.Slots.FindAsync(appointment.SlotId)
           ?? throw new SlotNotExistsException("Slot not exists for Id " + appointment.SlotId);
        appointment.CancelAppointment();
        slot.CancelBooking();
        await _dbContext.SaveChangesAsync();
    }

    public async void CompleteAppointmentAsync(Guid id)
    {
        var appointment = await _dbContext.Appointments.FindAsync(id)
           ?? throw new AppointmentNotExistsException("Appointment not exists for Id " + id);
        appointment.CompleteAppointment();
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Appointment>> GetAllAsync()
    {
        return await _dbContext.Appointments.ToListAsync();
    }

    public async Task<List<Appointment>> GetAppointmentsForPatientAsync(Guid id)
    {
        return await _dbContext.Appointments.Where(a => a.PatientId == id).ToListAsync();
    }

    public async Task<List<Appointment>> GetUpcomingAppointmentsAsync()
    {
        return await _dbContext.Appointments.Where(a => a.ReservedAt > DateTime.Now).ToListAsync();
    }
}