using Core.Infrastructure;
using Core.Models;
using Core.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
        public class CrudController : Controller
        {
                private DataContext _context;

                public CrudController(DataContext context)
                {
                        _context = context;
                }

                public IActionResult Index() => View(_context.Products.Include(p => p.Category));

                public async Task<IActionResult> Details(long id)
                {
                        Product product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

                        ProductViewModel model = ViewModelFactory.Details(product);

                        return View("ProductEditor", model);
                }
        }
}
