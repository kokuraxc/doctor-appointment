using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor_appointment.Domain.Entities
{
    public class Doctor
    {
        private Doctor()
        {
        }

        public Doctor(string username, string password, string firstName, string lastName)
        {
            Username = String.IsNullOrEmpty(username) ? throw new ArgumentNullException(nameof(Username)) : username;
            Password = String.IsNullOrEmpty(password) ? throw new ArgumentNullException(nameof(Password)) : password;
            FirstName = String.IsNullOrEmpty(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            LastName = String.IsNullOrEmpty(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = String.Empty;
        public List<Slot> Slots { get; set; } = new List<Slot>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
