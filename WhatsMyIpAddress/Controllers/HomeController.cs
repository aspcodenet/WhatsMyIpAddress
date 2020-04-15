using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Logging;
using WhatsMyIpAddress.Models;
using WhatsMyIpAddress.Services;

namespace WhatsMyIpAddress.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetIPService _ipService;

        public HomeController(ILogger<HomeController> logger, IGetIPService ipService)
        {
            _logger = logger;
            _ipService = ipService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        { 
            return View();
        }

        public IActionResult IP()
        {
            var ip = _ipService.GetIpAddress();
            return View("IP", ip);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
