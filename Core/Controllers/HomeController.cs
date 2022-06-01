using Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
        public class HomeController : Controller
        {
                private DataContext _context;

                public HomeController(DataContext context)
                {
                        _context = context;
                }

                public async Task<IActionResult> Index(long id)
                {
                        return View("Fruit", await _context.Products.FindAsync(id));
                }
        }
}
