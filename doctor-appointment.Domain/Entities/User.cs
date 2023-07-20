namespace doctor_appointment.Domain.Entities;

public class User
{
    private User()
    {
    }

    public User(string username, string password, string firstName, string lastName, UserRole role)
    {
        Username = String.IsNullOrEmpty(username) ? throw new ArgumentNullException(nameof(Username)) : username;
        Password = String.IsNullOrEmpty(password) ? throw new ArgumentNullException(nameof(Password)) : password;
        FirstName = String.IsNullOrEmpty(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
        LastName = String.IsNullOrEmpty(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
        Role = role;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = String.Empty;
    public UserRole Role { get; set; } = UserRole.Patient;

    public bool IsPatient()
    {
        return Role == UserRole.Patient;
    }

    public bool IsDoctor()
    {
        return Role == UserRole.Doctor;
    }
}

public enum UserRole
{
    Doctor = 1,
    Patient = 2
}