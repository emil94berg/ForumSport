using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ForumSport.Pages
{
    public class SpecificPostModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public SpecificPostModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public Models.Post Post { get; set; }
        public List<Models.Comment> Comments { get; set; }
        [BindProperty]
        public Models.Comment NewComment { get; set; }




        public async Task OnGetAsync(int postId)
        {
            var post = await _context.Posts.Where(p => p.Id == postId).FirstOrDefaultAsync();
            if(post != null)
            {
                Post = post;
            }

            Comments = await _context.Comments.Where(c => c.PostId == postId)
                .Include(c => c.User)
                .OrderBy(c => c.Date).ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(int postId)
        {
            NewComment.Date = DateTime.Now;
            NewComment.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            NewComment.PostId = postId;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Comments.Add(NewComment);
            await _context.SaveChangesAsync();

            return RedirectToPage("/SpecificPost", new { postId = postId });
        }
    }
}
