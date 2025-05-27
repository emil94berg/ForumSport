using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ForumSport.Pages.Admin
{
    [Authorize]
    public class AdminsidanModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public AdminsidanModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user.IsAdmin == false)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
