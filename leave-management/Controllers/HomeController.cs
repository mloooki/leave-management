using leave_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Controllers
{
    public class HomeController : Controller // Here the Controller names is HOME, So we must Have folder named HOME inside (Views Floder).
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() //there is a file called Index in HOME folder.
        {
            return View();
        }

        public IActionResult Privacy() //there is a file called Privacy in HOME folder.
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() //there is a file called Error in Views folder (inside shared folder.).
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); //Example of model.
        }
    }
}
