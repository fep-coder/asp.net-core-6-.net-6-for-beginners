using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
        public class AccountController : Controller
        {
                private SignInManager<IdentityUser> _signInManager;

                public AccountController(SignInManager<IdentityUser> signInManager)
                {
                        _signInManager = signInManager;
                }

                public IActionResult Login(string returnUrl) => View(returnUrl);
        }
}
