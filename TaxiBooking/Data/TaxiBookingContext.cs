using Microsoft.EntityFrameworkCore;
using TaxiBooking.Models;

namespace TaxiBooking.Data
{
    public class TaxiBookingContext : DbContext
    {
        public TaxiBookingContext(DbContextOptions<TaxiBookingContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Booking> Bookings { get; set; }


    }
}
