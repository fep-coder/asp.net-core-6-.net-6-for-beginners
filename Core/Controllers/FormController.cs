using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
        [AutoValidateAntiforgeryToken]
        public class FormController : Controller
        {
                private DataContext _context;

                public FormController(DataContext context)
                {
                        _context = context;
                }

                public async Task<IActionResult> Index(long id = 1)
                {
                        ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
                        return View(await _context.Products.Include(p => p.Category).FirstAsync(p => p.Id == id));
                }

                [HttpPost]
                //public IActionResult SubmitForm(string name, decimal price)
                public IActionResult SubmitForm([Bind("Name")] Product product)
                {
                        //TempData["name param"] = name;
                        //TempData["price param"] = price.ToString();

                        TempData["product"] = System.Text.Json.JsonSerializer.Serialize(product);

                        return RedirectToAction("Results");
                }

                public IActionResult Results()
                {
                        return View();
                }
        }
}
