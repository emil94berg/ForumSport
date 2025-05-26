using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSport.Pages.Admin
{
    public class ShowPostFromAPIModel : PageModel
    {
        public List<Models.Post> AllPosts { get; set; }
        public async Task OnGetAsync()
        {
            AllPosts = await DAL.PostAPIManager.GetPostsAsync();
        }
    }
}
