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
                public Product GetProduct([FromServices] ILogger<ProductsController> logger)
                {
                        logger.LogDebug("------------------------------- GetProduct Action Invoked -----------------------------");
                        return _context.Products.FirstOrDefault();
                }
        }
}
