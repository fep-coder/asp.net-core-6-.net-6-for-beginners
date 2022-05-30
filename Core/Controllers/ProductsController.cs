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

                // api/products
                [HttpPut]
                public void UpdateProduct([FromBody] Product product)
                {
                        _context.Update(product);
                        _context.SaveChanges();
                }

                // api/products/1
                [HttpDelete("{id}")]
                public void DeleteProduct(long id)
                {
                        _context.Products.Remove(new Product { Id = id });
                        _context.SaveChanges();
                }
        }
}
