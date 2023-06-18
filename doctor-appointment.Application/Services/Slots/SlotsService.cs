namespace doctor_appointment.Application.Services.Slots;

public class SlotsService : ISlotsService
{
    public CreateSlotResult CreateSlot(DateTime startDate, string doctorName, bool isReserved, decimal cost)
    {
        return new CreateSlotResult(Guid.NewGuid(), startDate, doctorName, isReserved, cost);
    }

    public List<CreateSlotResult> GetAllSlots()
    {
        return new List<CreateSlotResult>{
            new CreateSlotResult(Guid.NewGuid(), DateTime.Now, "doctor Name 1", false, (decimal)12.34),
            new CreateSlotResult(Guid.NewGuid(), DateTime.Now, "doctor Name 2", false, (decimal)98.34),
            new CreateSlotResult(Guid.NewGuid(), DateTime.Now, "doctor Name 3", true, (decimal)98.34),
        };
    }

    public List<CreateSlotResult> GetAvailableSlots()
    {
        return new List<CreateSlotResult>{
            new CreateSlotResult(Guid.NewGuid(), DateTime.Now, "doctor Name 1", true, (decimal)12.34),
            new CreateSlotResult(Guid.NewGuid(), DateTime.Now, "doctor Name 2", false, (decimal)98.34),
        };
    }
}