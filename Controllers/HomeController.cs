using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalSolutions.Data;
using MunicipalSolutions.Models;

namespace MunicipalSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Homepage: Load latest announcements
        public async Task<IActionResult> Index()
        {
            var announcements = await _context.Announcements
                .OrderByDescending(a => a.PostedAt)
                .Take(5)
                .ToListAsync();

            return View(announcements); // Passed to Index.cshtml
        }

        // ✅ All Announcements page
        public async Task<IActionResult> Announcements()
        {
            var announcements = await _context.Announcements
                .OrderByDescending(a => a.PostedAt)
                .ToListAsync();

            return View(announcements); // View: Views/Home/Announcements.cshtml
        }

        // ✅ All Discussions page
        public async Task<IActionResult> Discussions()
        {
            var discussions = await _context.DiscussionPosts
                .Include(d => d.Replies)
                .OrderByDescending(d => d.PostedAt)
                .ToListAsync();

            return View(discussions); // View: Views/Home/Discussions.cshtml
        }

        // Static municipal services page
        public IActionResult Services()
        {
            return View();
        }
        //privacy page
        public IActionResult Privacy()
        {
            return View();
        }
        // Default error page
        public IActionResult Error()
        {
            return View();
        }
    }
}