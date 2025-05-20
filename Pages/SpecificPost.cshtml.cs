using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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




        public async Task OnGetAsync(int postId)
        {
            var post = await _context.Posts.Where(p => p.Id == postId).FirstOrDefaultAsync();
            if(post != null)
            {
                Post = post;
            }
            


        }
    }
}
