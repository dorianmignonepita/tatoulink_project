using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace tatoulink.Views.Account
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public Credential Credential { get; set; }

        public IndexModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Credential.UserName, Credential.Password, false, false);
                if (result != null && result.Succeeded)
                {
                    return RedirectToPage("Index");
                }
                ViewData["LoginError"] = "Email ou Mot de passe incorrect";
            }

            return Page();
        }
    }

    public class Credential
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
