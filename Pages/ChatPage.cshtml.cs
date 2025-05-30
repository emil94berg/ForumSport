using ForumSport.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ForumSport.Pages
{
    [Authorize]
    public class ChatPageModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public ChatPageModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string LoggedInName { get; set; }


        [BindProperty]
        public Models.Chat Chat { get; set; }
        public List<Models.Chat> Chats { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            LoggedInName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Chats = await _context.Chats.Where(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) || c.ToUserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
            return Page();
                
        }
        public async Task<IActionResult> OnPostAsync(string chatId)
        {
            Chat.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Chat.Date = DateTime.Now;
            Chat.ToUserId = chatId;
            await DAL.ChatManagerAPI.PostChatAsync(Chat);
            return RedirectToPage("/ChatPage", new {chatId = LoggedInName});

            //_context.Chats.Add(Chat);
            //await _context.SaveChangesAsync();

        }
    }
}
