using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor_appointment.Domain.Entities
{
    public class Doctor
    {
        public Doctor()
        {
        }

        public Doctor(string firstName, string lastName)
        {
            FirstName = String.IsNullOrEmpty(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            LastName = String.IsNullOrEmpty(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = String.Empty;
        public List<Slot> Slots { get; set; } = new List<Slot>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
