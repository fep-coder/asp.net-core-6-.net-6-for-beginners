using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Pages
{
        public class EditModel : PageModel
        {
                private DataContext _context;
                public Product Product { get; set; }

                public EditModel(DataContext context)
                {
                        _context = context;
                }

                public async Task OnGetAsync(long id)
                {
                        Product = await _context.Products.FindAsync(id);
                }

                public async Task<IActionResult> OnPostAsync(long id, decimal price)
                {
                        Product product = await _context.Products.FindAsync(id);
                        if (product != null)
                        {
                                product.Price = price;
                        }
                        await _context.SaveChangesAsync();

                        return RedirectToPage();

                }
        }
}
