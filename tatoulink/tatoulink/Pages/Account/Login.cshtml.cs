using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace tatoulink.Views.Account
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            if (!ModelState.IsValid) return;
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
