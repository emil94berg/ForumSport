using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ForumSport.Pages.Admin
{
    public class CreateCategoryModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public CreateCategoryModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Models.Category NewCategory { get; set; }
        [BindProperty]
        public List<Models.Category> Categories { get; set; }
        public async Task OnGet()
        {
            Categories = await _context.Categories.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Categories.Add(NewCategory);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Admin/CreateCategory");
        }
    }
}
