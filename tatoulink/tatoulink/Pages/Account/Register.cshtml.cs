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

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = registerInfos.UserName,
                    PasswordHash = registerInfos.Password
                };
                var result = await _userManager.CreateAsync(user, registerInfos.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    if (error.Code == "DuplicateUserName")
                    {
                        ViewData["Pseudo"] = "Ce pseudo existe déjà";
                    }
                    else if (error.Code == "DuplicateEmail")
                    {
                        ViewData["Email"] = "Cet email existe déjà";
                    }
                    else if (error.Code.StartsWith("Password"))
                    {
                        ViewData["Password"] = "Requis : minimum de caractères et alphanumérics";
                    }
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
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
