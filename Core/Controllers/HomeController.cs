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
                        return View(await _context.Products.FindAsync(id));
                }

                public IActionResult Common(long id)
                {
                        return View("/Views/Shared/Common.cshtml");
                }

                public IActionResult List()
                {
                        return View(_context.Products);
                }
        }
}
