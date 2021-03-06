using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrivacyDb.Data;
using PrivacyDb.Models;

namespace PrivacyDb.Pages.ADMIN
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly PrivacyDb.Data.DataContext _context;

        public EditModel(PrivacyDb.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Livre Livre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Livre = await _context.Livres.FirstOrDefaultAsync(m => m.LivreID == id);

            if (Livre == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Livre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivreExists(Livre.LivreID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ListeDesEnre");
        }

        private bool LivreExists(int id)
        {
            return _context.Livres.Any(e => e.LivreID == id);
        }
    }
}
