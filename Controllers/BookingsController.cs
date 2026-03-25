using ColoradoAdventure.Data;
using ColoradoAdventure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColoradoAdventure.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int tourId)
        {
            var tour = await _context.Tours.FindAsync(tourId);
            if (tour == null) return NotFound();
            ViewBag.Tour = tour;
            return View(new Booking { TourId = tourId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            var tour = await _context.Tours.FindAsync(booking.TourId);
            if (tour == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            booking.UserId = user.Id;
            booking.BookingDate = DateTime.UtcNow;
            booking.CreatedDate = DateTime.UtcNow;
            booking.TotalPrice = tour.Price * booking.NumberOfPeople;
            booking.Status = BookingStatus.Pending;

            ModelState.Remove("UserId");
            ModelState.Remove("Tour");
            ModelState.Remove("User");

            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Confirm), new { id = booking.Id });
            }

            ViewBag.Tour = tour;
            return View(booking);
        }

        public async Task<IActionResult> Confirm(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var booking = await _context.Bookings
                .Include(b => b.Tour)
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == user!.Id);

            if (booking == null) return NotFound();
            return View(booking);
        }

        public async Task<IActionResult> MyBookings()
        {
            var user = await _userManager.GetUserAsync(User);
            var bookings = await _context.Bookings
                .Include(b => b.Tour)
                .Where(b => b.UserId == user!.Id)
                .OrderByDescending(b => b.CreatedDate)
                .ToListAsync();
            return View(bookings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == user!.Id);

            if (booking == null) return NotFound();
            booking.Status = BookingStatus.Cancelled;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MyBookings));
        }
    }
}
