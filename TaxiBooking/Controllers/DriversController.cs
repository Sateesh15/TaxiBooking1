using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiBooking.Data;
using TaxiBooking.Models;

namespace TaxiBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly TaxiBookingContext _context;

        public DriversController(TaxiBookingContext context)
        {
            _context = context;
        }

        // Register or update a driver
        [HttpPost("register")]
        public async Task<IActionResult> Register(Driver driver)
        {
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDriver), new { id = driver.DriverId }, driver);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Driver>> Login(string name, string password)
        {
            var Driver = await _context.Drivers.SingleOrDefaultAsync(u => u.Name == name && u.Password == password);
            if (Driver == null)
            {
                return NotFound("User not found.");
            }

            return Driver;
        }


        // Get a single driver
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // Get  drivers
        [HttpGet("availablel-drivers")]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            return  await _context.Drivers.ToListAsync();         
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("available-bookings")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAvailableBookings()
        {
            return await _context.Bookings.ToListAsync();
        }


        [HttpPost("accept-booking/{bookingId}")]
        public async Task<IActionResult> AcceptBooking(int bookingId, [FromBody] int driverId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            var driver = await _context.Drivers.FindAsync(driverId);

            if (booking == null)
            {
                return BadRequest("Booking is not available.");
            }

            if (booking.DriverId != null)
            {
                return BadRequest("Booking has already been accepted by another driver.");
            }

            if (driver == null)
            {
                return BadRequest("Driver does not exist.");
            }

            booking.DriverId = driverId;
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }

}
