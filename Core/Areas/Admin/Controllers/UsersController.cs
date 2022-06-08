using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.Controllers
{
        [Area("Admin")]
        public class UsersController : Controller
        {
                private UserManager<IdentityUser> _userManager;

                public UsersController(UserManager<IdentityUser> userManager)
                {
                        _userManager = userManager;
                }

                public IActionResult Index()
                {
                        return View(_userManager.Users.ToList());
                }
        }
}
