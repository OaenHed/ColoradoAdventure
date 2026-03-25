using ColoradoAdventure.Data;
using ColoradoAdventure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColoradoAdventure.Controllers
{
    public class ToursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToursController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? difficulty, decimal? minPrice, decimal? maxPrice, string? duration)
        {
            var query = _context.Tours.Where(t => t.IsActive).AsQueryable();

            if (!string.IsNullOrEmpty(difficulty) && Enum.TryParse<Difficulty>(difficulty, out var diff))
                query = query.Where(t => t.Difficulty == diff);

            if (minPrice.HasValue)
                query = query.Where(t => t.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(t => t.Price <= maxPrice.Value);

            ViewBag.Difficulty = difficulty;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            var tours = await query.OrderBy(t => t.Price).ToListAsync();
            return View(tours);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tour = await _context.Tours
                .Include(t => t.Reviews)
                    .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(t => t.Id == id && t.IsActive);

            if (tour == null) return NotFound();
            return View(tour);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tour tour)
        {
            if (ModelState.IsValid)
            {
                tour.CreatedDate = DateTime.UtcNow;
                _context.Tours.Add(tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tour);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null) return NotFound();
            return View(tour);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tour tour)
        {
            if (id != tour.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tour);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null) return NotFound();
            tour.IsActive = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
