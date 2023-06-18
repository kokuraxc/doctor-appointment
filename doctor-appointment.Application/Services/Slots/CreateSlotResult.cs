namespace doctor_appointment.Application.Services.Slots;

public record CreateSlotResult
(
    Guid Id,
    DateTime StartDate,
    string DoctorName,
    bool IsReserved,
    Decimal Cost
);
