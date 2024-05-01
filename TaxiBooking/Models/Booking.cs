public class Booking
{
    public int? BookingId { get; set; }
    public int UserId { get; set; }
    public int? DriverId { get; set; } // Nullable if not yet accepted by a driver
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime PickupTime { get; set; }
    public DateTime? AcceptedTime { get; set; }
    public double? Price { get; set; }
    public bool IsConfirmed { get; set; }

    // Parameterless constructor for Entity Framework Core
    public Booking() { }

    // Constructor
    public Booking(int bookingId, int userId, string origin, string destination, DateTime pickupTime, int? driverId, DateTime acceptedTime)
    {
        BookingId = bookingId;
        UserId = userId;
        DriverId = driverId;
        Origin = origin;
        Destination = destination;
        AcceptedTime = acceptedTime;
        PickupTime = pickupTime;
        IsConfirmed = false;
    }
}
