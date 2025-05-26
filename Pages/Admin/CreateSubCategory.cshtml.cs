using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ForumSport.Pages.Admin
{
    public class CreateSubCategoryModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public CreateSubCategoryModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Models.SubCategory NewSubCategory { get; set; }

        public List<Models.SubCategory> SubCategories { get; set; }


        public async Task OnGetAsync()
        {
            SubCategories = await _context.SubCategories.ToListAsync();
            var category = _context.Categories.Select(c => new
            {
                cId = c.Id,
                Name = c.Name
            });
            ViewData["CategoryId"] = new SelectList(category, "cId", "Name");

            
        }
        public async Task OnPostAsync()
        {
            _context.Add(NewSubCategory);
            await _context.SaveChangesAsync();
        }

    }
}
