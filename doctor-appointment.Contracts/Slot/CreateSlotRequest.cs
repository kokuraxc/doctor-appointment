namespace doctor_appointment.Contracts.Slot;

public record CreateSlotRequest(
    DateTime StartDate,
    // Guid DoctorId, // only one doctor, get rid of this Guid for now
    string DoctorName,
    bool IsReserved,
    Decimal Cost
);