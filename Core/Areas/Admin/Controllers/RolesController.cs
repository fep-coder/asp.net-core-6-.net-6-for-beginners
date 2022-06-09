using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.Controllers
{
        [Area("Admin")]
        public class RolesController : Controller
        {
                private UserManager<IdentityUser> _userManager;
                private RoleManager<IdentityRole> _roleManager;

                public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
                {
                        _userManager = userManager;
                        _roleManager = roleManager;
                }

                public IActionResult Index() => View(_roleManager.Roles);
        }
}
