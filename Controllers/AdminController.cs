using ColoradoAdventure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColoradoAdventure.Models;

namespace ColoradoAdventure.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalTours = await _context.Tours.CountAsync(t => t.IsActive);
            ViewBag.TotalBookings = await _context.Bookings.CountAsync();
            ViewBag.TotalRevenue = await _context.Bookings
                .Where(b => b.Status != BookingStatus.Cancelled)
                .SumAsync(b => b.TotalPrice);
            ViewBag.TotalUsers = await _userManager.Users.CountAsync();
            return View();
        }

        public async Task<IActionResult> Tours()
        {
            var tours = await _context.Tours.ToListAsync();
            return View(tours);
        }

        public async Task<IActionResult> Bookings()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Tour)
                .Include(b => b.User)
                .OrderByDescending(b => b.CreatedDate)
                .ToListAsync();
            return View(bookings);
        }

        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
    }
}
