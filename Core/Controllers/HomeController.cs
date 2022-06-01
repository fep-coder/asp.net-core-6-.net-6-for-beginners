using Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
        public class HomeController : Controller
        {
                private DataContext _context;

                public HomeController(DataContext context)
                {
                        _context = context;
                }

                public async Task<IActionResult> Index(long id = 1)
                {
                        return View(await _context.Products.FindAsync(id));
                }

                public IActionResult Common(long id)
                {
                        return View("/Views/Shared/Common.cshtml");
                }

                public async Task<IActionResult> List()
                {
                        ViewBag.AveragePrice = await _context.Products.AverageAsync(p => p.Price);

                        return View(await _context.Products.ToListAsync());
                }

                public IActionResult Redirect()
                {
                        TempData["value"] = "TempData value";
                        return RedirectToAction("Index", new { id = 1 });
                }
        }
}
