using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuiltInLoginSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BuiltInLoginSystem.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole()
                {
                    Name = roleViewModel.RoleName,
                };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(roleViewModel);
        }

        public IActionResult RoleList()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
        public async Task<IActionResult> AssignRole(string id)
        {
            ViewBag.roleId = id;
            var role = await roleManager.FindByIdAsync(id);

            if(role != null)
            {
                foreach (var user in userManager.Users)
                {

                }
            }
            return View();
        }
    }
}
