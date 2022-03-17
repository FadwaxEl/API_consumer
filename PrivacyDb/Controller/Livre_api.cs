using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivacyDb.Controller
{
    [ApiController]
    [Route("/controller")]
    public class Livre_api: ControllerBase
    {
        private readonly ILogger<Livre_api> _logger;

        public Livre_api(ILogger<Livre_api> logger)
        {
            _logger = logger;
        }
        public string Get()
        {
            _logger.LogInformation("Starting Index...");
            return "hello world";
        }


    }
}
