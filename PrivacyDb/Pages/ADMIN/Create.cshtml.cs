using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrivacyDb.Data;
using PrivacyDb.Models;

namespace PrivacyDb.Pages.ADMIN
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly PrivacyDb.Data.DataContext _context;

        public CreateModel(PrivacyDb.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Livre Livre { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Livres.Add(Livre);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ListeDesEnre");
        }
    }
}
