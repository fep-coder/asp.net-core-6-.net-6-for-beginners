using Microsoft.AspNetCore.Mvc;

namespace Core.Components
{
        [ViewComponent]
        public class PageSize : ViewComponent
        {
                public async Task<IViewComponentResult> InvokeAsync()
                {
                        HttpClient client = new();
                        HttpResponseMessage response = await client.GetAsync("http://google.com");

                        return View(response.Content.Headers.ContentLength);
                }
        }
}
