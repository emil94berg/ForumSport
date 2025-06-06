using ForumSport.Data;
using ForumSport.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ForumSport.Pages.Admin
{
    [Authorize]
    public class ShowPostFromAPIModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ShowPostFromAPIModel(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<Models.Post>? AllPosts { get; set; }
        public List<Models.Post> UserPosts { get; set; }
        public async Task<IActionResult> OnGetAsync(string userid, string uId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user.IsAdmin == false)
            {
                return RedirectToPage("/Index");
            }
            if (userid != null)
            {
                UserPosts = await DAL.PostAPIManager.GetPostsForUserAsync(userid);
                return Page();
            }
            if(uId != null)
            {
                var allPostFromUser = await _context.Posts.Where(p => p.UserId == uId).ToListAsync();
                _context.RemoveRange(allPostFromUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Admin/ReportedPost");
            }
            return Page();
        }
    }
}
