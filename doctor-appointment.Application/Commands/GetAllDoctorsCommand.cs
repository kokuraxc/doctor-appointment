using doctor_appointment.Contracts.User;
using MediatR;

namespace doctor_appointment.Application.Commands;

public record GetAllDoctorsCommand() : IRequest<List<GetDoctorResponse>>;

public class GetAllDoctorsCommandHandler : IRequestHandler<GetAllDoctorsCommand, List<GetDoctorResponse>>
{
    public async Task<List<GetDoctorResponse>> Handle(
        GetAllDoctorsCommand request,
        CancellationToken cancellationToken)
    {
        var doctors = new List<GetDoctorResponse>
        {
            new GetDoctorResponse(Id: Guid.NewGuid(),
                                  FirstName: "first 1",
                                  LastName: "last 1"),
        new GetDoctorResponse(Id: Guid.NewGuid(),
                            FirstName: "first 2",
                            LastName: "last 2")
        };

        return doctors;
    }
}