using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PrivacyDb.Data;
using PrivacyDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivacyDb.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private DataContext1 dataContext;

        public PrivacyModel(ILogger<PrivacyModel> logger, DataContext1 data)
        {
            _logger = logger;
            dataContext = data;
        }

        public void OnGet()
        {
            var livre = new Login() { Username = "Livreprivee" , Password = "hello"};
            dataContext.users.Add(livre);
            dataContext.SaveChanges();
        }
    }
}
