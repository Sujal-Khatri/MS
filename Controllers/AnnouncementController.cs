using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalSolutions.Data;
using MunicipalSolutions.Models;

namespace MunicipalSolutions.Controllers;

public class AnnouncementController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;

    public AnnouncementController(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    // Anyone can see announcements
    public async Task<IActionResult> Index()
    {
        var announcements = await _context.Announcements
            .OrderByDescending(a => a.PostedAt)
            .ToListAsync();

        return View(announcements);
    }

    // Only Admin can create
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(Announcement model, IFormFile? image)
    {
        if (image != null && image.Length > 0)
        {
            string uploads = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploads);
            string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            string filePath = Path.Combine(uploads, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            model.ImagePath = "/uploads/" + fileName;
        }

        _context.Announcements.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Announcements.FindAsync(id);
        if (item != null)
        {
            _context.Announcements.Remove(item);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}