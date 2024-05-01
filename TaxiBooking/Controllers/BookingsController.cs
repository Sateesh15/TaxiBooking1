using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiBooking.Data;
using TaxiBooking.Models;

namespace TaxiBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly TaxiBookingContext _context;

        public BookingsController(TaxiBookingContext context)
        {
            _context = context;
        }

        // Create a new booking
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(Booking booking)
        {

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
        }

        // Get a single booking
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // List all available bookings
        [HttpGet("available-bookings")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAvailableBookings()
        {
            var availableBookings = await _context.Bookings.ToListAsync();
            return availableBookings;
        }

        // Update a booking (e.g., confirm by user)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
