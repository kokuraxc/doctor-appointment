using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor_appointment.Contracts.User
{
    public record RegisterRequest
    (
        string Username,
        string Password,
        string FirstName,
        string LastName,
        UserRole Role
    );

    public enum UserRole
    {
        Doctor = 1,
        Patient = 2
    }
}
