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
        public void OnGet()
        {
        }

        public void OnPost()
        {
            return;
        }

        public class RegisterInfos
        {
            [Required]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Required]
            public string Firstname { get; set; }
            [Required]
            public string Surname { get; set; }
            [Required]
            public string Birthdate { get; set; }
        }
    }
}
