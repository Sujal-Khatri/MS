using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MunicipalSolutions.Data;
using MunicipalSolutions.Models;

namespace MunicipalSolutions.Controllers
{
    [Authorize]
    public class DiscussionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DiscussionController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Reply(DiscussionReply reply)
        {
            reply.UserId = _userManager.GetUserId(User);
            reply.RepliedAt = DateTime.Now;

            _context.DiscussionReplies.Add(reply);
            await _context.SaveChangesAsync();

            return RedirectToAction("Discussions", "Home");
        }
    }
}