namespace doctor_appointment.Application.Services.Slots;

public interface ISlotsService
{
    CreateSlotResult CreateSlot(DateTime startDate, string doctorName, bool isReserved, Decimal cost);
    List<CreateSlotResult> GetAllSlots();
    List<CreateSlotResult> GetAvailableSlots();
}