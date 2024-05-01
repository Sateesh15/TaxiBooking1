namespace TaxiBooking.Models
{
    public class User
    {

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // In practice, store hashed passwords
        public string PhoneNumber { get; set; }

        // Constructor
        public User(int userId, string name, string email, string password, string phoneNumber)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
        }
    }
}
