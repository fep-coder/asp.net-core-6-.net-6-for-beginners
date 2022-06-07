using Core.Infrastructure;
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
        }
}
