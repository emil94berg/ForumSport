using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ForumSport.Pages
{
    [Authorize]
    public class NewPostPageModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public NewPostPageModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Post MyNewPost { get; set; }
        [BindProperty]
        public IFormFile? PostImage { get; set; }


        public IActionResult OnGet(int catId)
        {
            var subCategorieList = _context.SubCategories
                .Include(sc => sc.Category)
                .Where(sc => sc.CategoryId == catId)
                .Select(sc => new
                {
                    ScId = sc.Id,
                    Name = $"{sc.Name} ({sc.Category.Name})"
                });


            ViewData["SubCategoryId"] = new SelectList(subCategorieList, "ScId", "Name");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string fileName = "";
            if (PostImage != null)
            {
                fileName = Guid.NewGuid().ToString() + "_" + PostImage.FileName;
                using (var fileStream = new FileStream("./wwwroot/img/" + fileName, FileMode.Create))
                {
                    await PostImage.CopyToAsync(fileStream);
                }
            }


            MyNewPost.ImgString = fileName;
            MyNewPost.PostDate = DateTime.Now;
            MyNewPost.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Posts.Add(MyNewPost);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
