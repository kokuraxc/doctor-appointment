using doctor_appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor_appointment_Tests.Domain
{
    internal class DoctorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Pass()
        {
            var firstName = "First";
            var lastName = "Last";
            var username = "username";
            var password = "password";
            var doctor = new Doctor(username, password, firstName, lastName);
            Assert.IsNotNull(doctor.Id);
            Assert.That(doctor.FirstName, Is.EqualTo(firstName));
            Assert.That(doctor.LastName, Is.EqualTo(lastName));
            Assert.That(doctor.Username, Is.EqualTo(username));
            Assert.That(doctor.Password, Is.EqualTo(password));
            Assert.That(doctor.Slots, Is.Empty);
            Assert.That(doctor.Appointments, Is.Empty);
        }

        [Test]
        public void Constructor_EmptyOrNullArgument()
        {
            var username = "username";
            var password = "password";
            var firstName = "";
            var lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Doctor(username, password, firstName, lastName));

            username = "username";
            password = "password";
            firstName = null;
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Doctor(username, password, firstName, lastName));

            username = "username";
            password = "password";
            firstName = "First";
            lastName = "";
            Assert.Throws<ArgumentNullException>(() => new Doctor(username, password, firstName, lastName));

            username = "username";
            password = "password";
            firstName = "First";
            lastName = null;
            Assert.Throws<ArgumentNullException>(() => new Doctor(username, password, firstName, lastName));

            username = "";
            password = "password";
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Doctor(username, password, firstName, lastName));

            username = null;
            password = "password";
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Doctor(username, password, firstName, lastName));

            username = "username";
            password = "";
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Doctor(username, password, firstName, lastName));

            username = "username";
            password = null;
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Doctor(username, password, firstName, lastName));
        }
    }
}
