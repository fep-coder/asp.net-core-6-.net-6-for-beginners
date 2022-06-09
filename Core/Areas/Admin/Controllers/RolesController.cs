﻿using Microsoft.AspNetCore.Identity;
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
        }
}