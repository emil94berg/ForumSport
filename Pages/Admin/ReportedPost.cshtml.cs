using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ForumSport.Pages.Admin
{
    [Authorize]
    public class ReportedPostModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public ReportedPostModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Models.Post> ReportedPosts { get; set; }
        public async Task<IActionResult> OnGetAsync(int deleteId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user.IsAdmin == false)
            {
                return RedirectToPage("/Index");
            }
            if (deleteId != 0)
            {
                var deletePost = await _context.Posts.Where(x => x.Id == deleteId).FirstOrDefaultAsync();
                var deleteComments = await _context.Comments.Where(c => c.PostId == deleteId).ToListAsync();

                _context.RemoveRange(deleteComments);
                _context.Posts.Remove(deletePost);
                await _context.SaveChangesAsync();
                return RedirectToPage();
                
            }
            ReportedPosts = await _context.Posts.Where(p => p.Reported == true).ToListAsync();
            return Page();
        }
    }
}
