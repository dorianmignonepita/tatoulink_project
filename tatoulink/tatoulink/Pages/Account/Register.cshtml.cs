using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace tatoulink.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterInfos registerInfos { get; set; }

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public void OnGet()
        {
        }

        public void OnPost()
        {
            Debugger.Break();
        }

        public class RegisterInfos
        {
            [Required]
            public string Password { get; set; }
            [Required]
            public string UserName { get; set; }
        }
    }
}
