using doctor_appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor_appointment_Tests.Domain
{
    internal class UserTests
    {
        [Test]
        public void Constructor_Pass()
        {
            var firstName = "First";
            var lastName = "Last";
            var username = "username";
            var password = "password";
            var role = UserRole.Patient;
            var user = new User(username, password, firstName, lastName, role);
            Assert.IsNotNull(user.Id);
            Assert.That(user.FirstName, Is.EqualTo(firstName));
            Assert.That(user.LastName, Is.EqualTo(lastName));
            Assert.That(user.Username, Is.EqualTo(username));
            Assert.That(user.Password, Is.EqualTo(password));
            Assert.That(user.Role, Is.EqualTo(role));

            firstName = "First";
            lastName = "Last";
            username = "username";
            password = "password";
            role = UserRole.Doctor;
            user = new User(username, password, firstName, lastName, role);
            Assert.IsNotNull(user.Id);
            Assert.That(user.FirstName, Is.EqualTo(firstName));
            Assert.That(user.LastName, Is.EqualTo(lastName));
            Assert.That(user.Username, Is.EqualTo(username));
            Assert.That(user.Password, Is.EqualTo(password));
            Assert.That(user.Role, Is.EqualTo(role));
        }

        [Test]
        public void Constructor_NullOrEmptyArgument()
        {
            var username = "username";
            var password = "password";
            var firstName = "";
            var lastName = "Last";
            var role = UserRole.Doctor;
            Assert.Throws<ArgumentNullException>(() => new User(username, password, firstName, lastName, role));

            username = "username";
            password = "password";
            firstName = null;
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new User(username, password, firstName, lastName, role));

            username = "username";
            password = "password";
            firstName = "First";
            lastName = "";
            Assert.Throws<ArgumentNullException>(() => new User(username, password, firstName, lastName, role));

            username = "username";
            password = "password";
            firstName = "First";
            lastName = null;
            Assert.Throws<ArgumentNullException>(() => new User(username, password, firstName, lastName, role));

            username = "";
            password = "password";
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new User(username, password, firstName, lastName, role));

            username = null;
            password = "password";
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new User(username, password, firstName, lastName, role));

            username = "username";
            password = "";
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new User(username, password, firstName, lastName, role));

            username = "username";
            password = null;
            firstName = "First";
            lastName = "Last";
            Assert.Throws<ArgumentNullException>(() => new User(username, password, firstName, lastName, role));
        }

        [Test]
        public void IsDoctor_IsPatient_Pass()
        {
            var firstName = "First";
            var lastName = "Last";
            var username = "username";
            var password = "password";
            var role = UserRole.Patient;
            var user = new User(username, password, firstName, lastName, role);
            
            Assert.That(user.IsPatient(), Is.True);
            Assert.That(user.IsDoctor(), Is.False);

            role = UserRole.Doctor;
            user = new User(username, password, firstName, lastName, role);

            Assert.That(user.IsPatient(), Is.False);
            Assert.That(user.IsDoctor(), Is.True);
        }
    }
}
