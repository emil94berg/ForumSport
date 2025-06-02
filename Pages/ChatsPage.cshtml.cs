using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ForumSport.Pages
{
    public class ChatsPageModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public ChatsPageModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public Dictionary<string, List<Models.Chat>> ChatsGrouped { get; set; }
        public async Task OnGetAsync()
        {
            var currentPerson = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var allChats = await _context.Chats
                .Where(c => c.UserId == currentPerson || c.ToUserId == currentPerson)
                .Include(c => c.User)
                .Include(c => c.ToUser)
                .ToListAsync();

            ChatsGrouped = allChats.GroupBy(c => c.UserId == currentPerson ? c.ToUserId : c.UserId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
