namespace TaxiBooking.Models
{
    public class Driver
    {
        public string Name { get; set; } 
        public string Mobile { get; set; }

        public string Password { get; set; }
        public int? DriverId { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpiration { get; set; }
        public bool IsAvailable { get; set; }

        public Driver() { }
        // Parameterized constructor
        public Driver( string licenseNumber, DateTime licenseExpiration, bool isAvailable, string password,string mobile, string name)
        {
            Name = name;
            Mobile = mobile;
            LicenseNumber = licenseNumber;
            LicenseExpiration = licenseExpiration;
            IsAvailable = isAvailable;
            Password = password;
        }
    }
}
