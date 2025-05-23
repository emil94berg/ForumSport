using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumSport.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ForumSport.Models.Category> Categories { get; set; }
        public DbSet<ForumSport.Models.SubCategory> SubCategories { get; set; }
        public DbSet<ForumSport.Models.Post> Posts { get; set; }
        public DbSet<ForumSport.Models.Comment> Comments { get; set; }
    }
}
