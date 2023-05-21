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

        public void OnPost()
        {
            return;
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
