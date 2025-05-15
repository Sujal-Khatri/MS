using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MunicipalSolutions.Data;
using MunicipalSolutions.Models;

namespace MunicipalSolutions.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /User/Dashboard
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View(new DiscussionPost());
        }

        // POST: /User/PostDiscussion
        [HttpPost]
        public async Task<IActionResult> PostDiscussion(DiscussionPost post)
        {
            post.UserId = _userManager.GetUserId(User);
            post.PostedAt = DateTime.Now;

            _context.DiscussionPosts.Add(post);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Your issue has been posted!";
            return RedirectToAction("Dashboard");
        }
    }
}