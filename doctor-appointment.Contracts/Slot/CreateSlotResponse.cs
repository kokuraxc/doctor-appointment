namespace doctor_appointment.Contracts.Slot;

public record CreateSlotResponse(
    Guid Id,
    DateTime StartDate,
    // Guid DoctorId, // only one doctor, get rid of this Guid for now
    string DoctorName,
    bool IsReserved,
    decimal Cost
);