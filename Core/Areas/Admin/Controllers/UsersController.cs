using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.Controllers
{
        [Area("Admin")]
        public class UsersController : Controller
        {
                public IActionResult Index()
                {
                        return View();
                }
        }
}
