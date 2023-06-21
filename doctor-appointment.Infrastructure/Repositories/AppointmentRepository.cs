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

    public async Task<Appointment> AddAsync(Guid slotId, Guid patientId)
    {
        var slot = await _dbContext.Slots.FindAsync(slotId)
            ?? throw new ArgumentException("Slot not exists for ID " + slotId);
        if(slot.IsReserved)
        {
            throw new Exception("Slot is already booked");
        }
        var patient = await _dbContext.Patients.FindAsync(patientId)
            ?? throw new ArgumentException("Patient not exists for ID " + patientId);
        var appointment = new Appointment{
            SlotId = slotId,
            PatientId = patientId,
            PatientName = patient.FirstName + ' ' + patient.LastName,
            ReservedAt = slot.StartDate
        };
        slot.BookSlot();
        await _dbContext.Appointments.AddAsync(appointment);
        await _dbContext.SaveChangesAsync();
        return appointment;
    }

    public async Task<Appointment> CancelAppointmentAsync(Guid id)
    {
        var appointment = await _dbContext.Appointments.FindAsync(id)
            ?? throw new AppointmentNotExistsException("Appointment not exists for Id " + id);
        var slot = await _dbContext.Slots.FindAsync(appointment.SlotId)
           ?? throw new SlotNotExistsException("Slot not exists for Id " + appointment.SlotId);
        if (appointment.Status != AppointmentStatus.Confirmed){
            throw new Exception("Can only cancel confirmed appointment.");
        }
        appointment.CancelAppointment();
        slot.CancelBooking();
        await _dbContext.SaveChangesAsync();
        return appointment;
    }

    public async Task<Appointment> CompleteAppointmentAsync(Guid id)
    {
        var appointment = await _dbContext.Appointments.FindAsync(id)
           ?? throw new AppointmentNotExistsException("Appointment not exists for Id " + id);
        appointment.CompleteAppointment();
        await _dbContext.SaveChangesAsync();
        return appointment;
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
        return await _dbContext.Appointments.Where(a => a.ReservedAt > DateTime.Now && a.Status == AppointmentStatus.Confirmed).ToListAsync();
    }
}