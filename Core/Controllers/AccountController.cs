using Core.Models.ViewModels;
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

                [HttpPost]
                public async Task<IActionResult> Login(LoginViewModel loginVM)
                {
                        if (ModelState.IsValid)
                        {
                                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);

                                if (result.Succeeded)
                                {
                                        return Redirect(loginVM.ReturnUrl ?? "/");
                                }

                                ModelState.AddModelError("", "Invalid username or password");
                        }

                        return View(loginVM);
                }

                public IActionResult Details() => View(new AuthDetailsViewModel { Cookie = Request.Cookies[".AspNetCore.Identity.Application"] });

                public async Task Logout() => await _signInManager.SignOutAsync();
        }
}
