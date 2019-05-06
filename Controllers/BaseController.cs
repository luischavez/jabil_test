using Microsoft.AspNetCore.Mvc;
using jabil_test.Models;

namespace jabil_test.Controllers
{
    /*
     * Base controller.
     * 
     * exposes materials db context in protected scope.
     */
    public class BaseController : Controller
    {
        // Db context.
        protected readonly MaterialsContext _context;

        public BaseController(MaterialsContext context)
        {
            _context = context;
        }
    }
}
