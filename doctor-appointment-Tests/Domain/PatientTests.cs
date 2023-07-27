using doctor_appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor_appointment_Tests.Domain
{
    internal class PatientTests
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
            var patient = new Patient(username, password, firstName, lastName);
            Assert.IsNotNull(patient.Id);
            Assert.That(patient.FirstName, Is.EqualTo(firstName));
            Assert.That(patient.LastName, Is.EqualTo(lastName));
            Assert.That(patient.Username, Is.EqualTo(username));
            Assert.That(patient.Password, Is.EqualTo(password));
            Assert.That(patient.Appointments, Is.Empty);
        }

        [Test]
        public void Constructor_EmptyOrNullArgument()
        {
            var username = "username";
            var password = "password";
            var firstName = "";
            var lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Patient(username, password, firstName, lastName));

            username = "username";
            password = "password";
            firstName = null;
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Patient(username, password, firstName, lastName));

            username = "username";
            password = "password";
            firstName = "First";
            lastName = "";
            Assert.Throws<ArgumentNullException>(() => new Patient(username, password, firstName, lastName));

            username = "username";
            password = "password";
            firstName = "First";
            lastName = null;
            Assert.Throws<ArgumentNullException>(() => new Patient(username, password, firstName, lastName));

            username = "";
            password = "password";
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Patient(username, password, firstName, lastName));

            username = null;
            password = "password";
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Patient(username, password, firstName, lastName));

            username = "username";
            password = "";
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Patient(username, password, firstName, lastName));

            username = "username";
            password = null;
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new Patient(username, password, firstName, lastName));
        }
    }
}
