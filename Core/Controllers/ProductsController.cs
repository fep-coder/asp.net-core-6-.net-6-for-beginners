using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
        [Route("api/[controller]")]
        public class ProductsController : ControllerBase
        {
                // api/products
                [HttpGet]
                public IEnumerable<Product> GetProducts()
                {
                        return new Product[]
                        {
                                new Product() { Name = "Product #1" },
                                new Product() { Name = "Product #2" }
                        };
                }

                // api/products/1
                [HttpGet("{id}")]
                public Product GetProduct()
                {
                        return new Product() { Id = 1, Name = "Product #1" };
                }
        }
}
