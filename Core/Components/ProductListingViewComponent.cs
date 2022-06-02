using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Components
{
        [ViewComponent(Name = "JuicyFruit")]
        public class ProductListingViewComponent : ViewComponent
        {
                private DataContext _context;

                public IEnumerable<Product> Products;

                public ProductListingViewComponent(DataContext context)
                {
                        _context = context;
                }

                public string Invoke()
                {
                        return $"There are {_context.Products.Count()} products";
                }
        }
}
