using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrivacyDb.Data;
using PrivacyDb.Models;

namespace PrivacyDb.Pages.ADMIN
{
    [Authorize]
    public class ListeDesEnre : PageModel
    {
        private readonly PrivacyDb.Data.DataContext _context;

        public ListeDesEnre(PrivacyDb.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Livre> Livre { get; set; }

        public async Task OnGetAsync()
        {
            Livre = await _context.Livres.ToListAsync();
        }
    }
}
