using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ForumSport.Pages
{
    public class CategoryPageModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public CategoryPageModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Models.SubCategory> AllSubCategories { get; set; }
        public List<Models.Post> AllPostsForCategory { get; set; }
        public int SelectedCategoryId { get; set; }

        public async Task<IActionResult> OnGetAsync(int thisCategoryId, int subId)
        {
            AllSubCategories = await _context.SubCategories.ToListAsync();
            SelectedCategoryId = thisCategoryId;
            List<Models.Category> categoryId = new List<Models.Category>();
            if (_context.Categories != null)
            {
                categoryId = await _context.Categories.ToListAsync();
            }
            if (subId == 0)
            {
                var allFootballPosts = await _context.Posts
                                .Include(p => p.SubCategory)
                                .ThenInclude(s => s.Category)
                                .Where(p => p.SubCategory.CategoryId == thisCategoryId).OrderByDescending(p => p.PostDate).ToListAsync();
                AllPostsForCategory = allFootballPosts;
            }
            else
            {
                var allFootballPosts = await _context.Posts
                                .Include(p => p.SubCategory)
                                .Where(p => p.SubCategory.Id == subId).OrderByDescending(p => p.PostDate).ToListAsync();
                AllPostsForCategory = allFootballPosts;
            }

            return Page();
        }
    }
}
