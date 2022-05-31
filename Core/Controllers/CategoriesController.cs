using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.JsonPatch;
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

                // api/categories/1
                [HttpPatch("{id}")]
                public async Task<Category> PatchCategory(long id, JsonPatchDocument<Category> patchDoc)
                {
                        Category category = await _context.Categories.FindAsync(id);

                        if (category != null)
                        {
                                patchDoc.ApplyTo(category);
                                await _context.SaveChangesAsync();
                        }

                        return category;
                }

        }
}
