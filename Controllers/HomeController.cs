using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jabil_test.Models;

namespace jabil_test.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(MaterialsContext context): base(context)
        {
        }

        public IActionResult Index()
        {
            var Buildings = _context.Buildings.ToList();

            return View(Buildings);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
