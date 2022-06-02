using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Components
{
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
                        if (RouteData.Values["controller"] != null)
                        {
                                return "Controller request";
                        }
                        else
                        {
                                return "Razor Page request";
                        }
                }
        }
}
