using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MunicipalSolutions.Data;
using MunicipalSolutions.Models;

namespace MunicipalSolutions.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/Dashboard
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View(new Announcement());
        }

        // POST: /Admin/PostAnnouncement
        [HttpPost]
        public async Task<IActionResult> PostAnnouncement(Announcement model)
        {
            if (ModelState.IsValid)
            {
                _context.Announcements.Add(model);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Announcement posted successfully!";
                return RedirectToAction("Dashboard");
            }

            // Return view with model if validation fails
            return View("Dashboard", model);
        }
    }
}