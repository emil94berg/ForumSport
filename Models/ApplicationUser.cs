using Microsoft.AspNetCore.Identity;

namespace ForumSport.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
        public string? ImgString { get; set; }

    }
}
