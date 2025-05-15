using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MunicipalSolutions.Models;

namespace MunicipalSolutions.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<DiscussionPost> DiscussionPosts { get; set; }
        public DbSet<DiscussionReply> DiscussionReplies { get; set; } // ✅ Add this
    }
}