using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
        [Route("api/[controller]")]
        public class ProductsController : ControllerBase
        {
                private DataContext _context;

                public ProductsController(DataContext context)
                {
                        _context = context;
                }

                // api/products
                [HttpGet]
                public IEnumerable<Product> GetProducts()
                {
                        return _context.Products;
                }

                // api/products/1
                [HttpGet("{id}")]
                public Product GetProduct(long id, [FromServices] ILogger<ProductsController> logger)
                {
                        logger.LogDebug("------------------------------- GetProduct Action Invoked -----------------------------");
                        return _context.Products.Find(id);
                }

                // api/products
                [HttpPost]
                public void SaveProduct([FromBody] Product product)
                {
                        _context.Products.Add(product);
                        _context.SaveChanges();
                }
        }
}
