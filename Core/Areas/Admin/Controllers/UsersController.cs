using Core.Models;
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

                public IActionResult Index() => View(_userManager.Users.ToList());

                public IActionResult Create() => View();

                [HttpPost]
                public async Task<IActionResult> Create(User user)
                {
                        if (ModelState.IsValid)
                        {
                                IdentityUser newUser = new IdentityUser { UserName = user.UserName, Email = user.Email };
                                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

                                if (result.Succeeded)
                                {
                                        return RedirectToAction("Index");
                                }

                                foreach (IdentityError error in result.Errors)
                                {
                                        ModelState.AddModelError("", error.Description);
                                }

                        }

                        return View(user);
                }
        }
}
