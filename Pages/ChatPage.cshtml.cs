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

        public async Task<IActionResult> OnGetAsync(string chatId)
        {
            LoggedInName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(chatId))
            {
                return NotFound("Hittade in chatId");
            }

            Chats = await _context.Chats
                .Where(c => (c.UserId == LoggedInName && c.ToUserId == chatId) ||
                (c.UserId == chatId && c.ToUserId == LoggedInName))
                .OrderByDescending(c => c.Date)
                .ToListAsync();

            if (Chats != null && Chats.Any(c => !c.Read))
            {
                foreach(var chat in Chats)
                {
                    if(chat.UserId != LoggedInName || chat.UserId == chat.ToUserId)
                    {
                        chat.Read = true;
                    } 
                }
                _context.Chats.UpdateRange(Chats);
                _context.SaveChanges();
            }

            return Page();


              
        }
        public async Task<IActionResult> OnPostAsync(string chatId)
        {
            Chat.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Chat.Date = DateTime.Now;
            Chat.ToUserId = chatId;
            await DAL.ChatManagerAPI.PostChatAsync(Chat);
            return RedirectToPage("/ChatPage", new {chatId = chatId});
        }
    }
}
