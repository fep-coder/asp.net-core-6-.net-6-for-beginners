using Core.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

                public IActionResult Create() => View();

                [HttpPost]
                public async Task<IActionResult> Create([MinLength(2), Required] string name)
                {
                        if (ModelState.IsValid)
                        {
                                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

                                if (result.Succeeded)
                                {
                                        return RedirectToAction("Index");
                                }
                                else
                                {
                                        foreach (IdentityError error in result.Errors)
                                        {
                                                ModelState.AddModelError("", error.Description);
                                        }
                                }
                        }

                        return View();
                }

                public async Task<IActionResult> Edit(string id)
                {
                        IdentityRole role = await _roleManager.FindByIdAsync(id);

                        IEnumerable<IdentityUser> members = await _userManager.GetUsersInRoleAsync(role.Name);
                        IEnumerable<IdentityUser> nonMembers = _userManager.Users.ToList().Except(members);

                        return View(new RoleViewModel
                        {
                                Role = role,
                                NonMembers = nonMembers,
                                Members = members
                        });
                }

                [HttpPost]
                public async Task<IActionResult> Edit(RoleViewModel roleVM)
                {
                        IdentityResult result;

                        foreach (string id in roleVM.AddIds ?? Array.Empty<string>())
                        {
                                IdentityUser user = await _userManager.FindByIdAsync(id);
                                result = await _userManager.AddToRoleAsync(user, roleVM.RoleName);
                        }

                        foreach (string id in roleVM.DeleteIds ?? new string[] { })
                        {
                                IdentityUser user = await _userManager.FindByIdAsync(id);
                                result = await _userManager.RemoveFromRoleAsync(user, roleVM.RoleName);
                        }

                        return Redirect(Request.Headers["Referer"].ToString());
                }

                public async Task<IActionResult> Delete(string id)
                {
                        IdentityRole role = await _roleManager.FindByIdAsync(id);

                        await _roleManager.DeleteAsync(role);

                        return RedirectToAction("Index");
                }
        }
}
