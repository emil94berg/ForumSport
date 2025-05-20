using ForumSport.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ForumSport.Pages
{
    public class EditProfilePageModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public EditProfilePageModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public IFormFile ProfilePic { get; set; }
        public ApplicationUser CurrentUser { get; set; }

        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string fileName = "";
            if(ProfilePic != null)
            {
                fileName = Guid.NewGuid().ToString()+ "_" + ProfilePic.FileName;
                using (var fileStream = new FileStream("./wwwroot/img/" + fileName, FileMode.Create))
                {
                    await ProfilePic.CopyToAsync(fileStream);
                }
            }

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(user.ImgString))
                {
                    var oldImg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", user.ImgString);
                    if (System.IO.File.Exists(oldImg))
                    {
                        System.IO.File.Delete(oldImg);
                    }
                }


                user.ImgString = fileName;

            }
            var result = await _userManager.UpdateAsync(user);
            return RedirectToPage();

        }
    }
}
