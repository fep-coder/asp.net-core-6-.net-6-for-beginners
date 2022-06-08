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

                public IActionResult Create() => View("ProductEditor", ViewModelFactory.Create(new Product(), _context.Categories));

                [HttpPost]
                public async Task<IActionResult> Create([FromForm] Product product)
                {
                        if (ModelState.IsValid)
                        {
                                _context.Products.Add(product);
                                await _context.SaveChangesAsync();

                                return RedirectToAction("Index");
                        }

                        return View("ProductEditor", ViewModelFactory.Create(product, _context.Categories));
                }

                public async Task<IActionResult> Edit(long id)
                {
                        Product product = await _context.Products.FindAsync(id);

                        if (product != null)
                        {
                                ProductViewModel model = ViewModelFactory.Edit(product, _context.Categories);

                                return View("ProductEditor", model);
                        }

                        return View("ProductEditor", ViewModelFactory.Create(new Product(), _context.Categories));
                }
        }
}
