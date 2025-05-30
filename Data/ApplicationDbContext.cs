using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumSport.Data
{
    public class ApplicationDbContext : IdentityDbContext<ForumSport.Models.ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ForumSport.Models.Category> Categories { get; set; }
        public DbSet<ForumSport.Models.SubCategory> SubCategories { get; set; }
        public DbSet<ForumSport.Models.Post> Posts { get; set; }
        public DbSet<ForumSport.Models.Comment> Comments { get; set; }
        public DbSet<ForumSport.Models.Chat> Chats { get; set; }
    }
}
