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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Reply(DiscussionReply reply)
        {
            reply.UserId = _userManager.GetUserId(User);
            reply.RepliedAt = DateTime.Now;

            _context.DiscussionReplies.Add(reply);
            await _context.SaveChangesAsync();

            return RedirectToAction("Discussions", "Home");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.DiscussionPosts.FindAsync(id);
            if (post == null || post.UserId != _userManager.GetUserId(User))
                return Forbid();

            _context.DiscussionPosts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction("Discussions", "Home");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteReply(int id)
        {
            var reply = await _context.DiscussionReplies.FindAsync(id);
            if (reply == null || reply.UserId != _userManager.GetUserId(User))
                return Forbid();

            _context.DiscussionReplies.Remove(reply);
            await _context.SaveChangesAsync();
            return RedirectToAction("Discussions", "Home");
        }
    }
}