using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

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

                public IViewComponentResult Invoke()
                {
                        //return Content("This is a <h3><i>string</i></h3>");
                        return new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i></h3>"));
                }
        }
}
