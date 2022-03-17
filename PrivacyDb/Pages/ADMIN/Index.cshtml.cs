using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PrivacyDb.Pages
{
    public class IndexModel1 : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //private List<Claim> claims;

        public IndexModel1(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /*[BindProperty]
        public Account infos { get; set; }*/
        public IActionResult OnGet()
        {
            if(User.Identity.IsAuthenticated == true)
            {
                return  Redirect("ListeDesEnre");
            }
            return Page();
        }
        public async Task<IActionResult> OnPost(string username, string password, string ReturnUrl)
        {
            if (username == "admin") { 

               var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
               };
            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.
            AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Redirect(ReturnUrl == null ? "/ADMIN/ListeDesEnre" : ReturnUrl);
        }
            return Page();
        }
    }
}



/*public class Account
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}*/