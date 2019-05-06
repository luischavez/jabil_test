using Microsoft.AspNetCore.Mvc;
using jabil_test.Models;

namespace jabil_test.Controllers
{
    public class BaseController : Controller
    {
        protected readonly MaterialsContext _context;

        public BaseController(MaterialsContext context)
        {
            _context = context;
        }
    }
}
