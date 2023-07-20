using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor_appointment.Contracts.User
{
    public record LoginRequest
    (
        string Username,
        string Password
    );
}
