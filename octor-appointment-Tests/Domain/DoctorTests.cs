using doctor_appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octor_appointment_Tests.Domain
{
    internal class DoctorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Doctor_Constructor_Pass()
        {
            var firstName = "First";
            var lastName = "Last";
            var doctor = new Doctor(firstName, lastName);
            Assert.IsNotNull(doctor.Id);
            Assert.That(doctor.FirstName, Is.EqualTo(firstName));
            Assert.That(doctor.LastName, Is.EqualTo(lastName));
            Assert.IsTrue(doctor.Slots.Count == 0);
            Assert.IsTrue(doctor.Appointments.Count == 0);
        }

        [Test]
        public void Doctor_Constructor_EmptyOrNullArgument()
        {
            var firstName = "";
            var lastName = "Last";            
            Assert.Throws<ArgumentNullException>(() => new Doctor( firstName, lastName));

            firstName = null;
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Doctor(firstName, lastName));

            firstName = "First";
            lastName = "";
            Assert.Throws<ArgumentNullException>(() => new Doctor(firstName, lastName));

            firstName = "First";
            lastName = null;
            Assert.Throws<ArgumentNullException>(() => new Doctor(firstName, lastName));

        }
    }
}
