using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class CategoriesController : ControllerBase
        {
                private DataContext _context;

                public CategoriesController(DataContext context)
                {
                        _context = context;
                }

                // api/categories/1
                [HttpGet("{id}")]
                public async Task<Category> GetCategory(long id)
                {
                        Category category = await _context.Categories.Include(c => c.Products).FirstAsync(c => c.Id == id);
                        if (category.Products != null)
                        {
                                foreach (Product product in category.Products)
                                {
                                        product.Category = null;
                                }
                        }

                        return category;
                }

        }
}
