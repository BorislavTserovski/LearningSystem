using LearningSystem.Areas.Admin.Models.Users;
using LearningSystem.Data.Models;
using LearningSystem.Infrastructure.Extensions;
using LearningSystem.Services.Admin.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Areas.Admin.Controllers
{
    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService users;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UsersController(IAdminUserService users,
            RoleManager<IdentityRole>roleManager, UserManager<User>userManager)
        {
            this.users = users;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users =await this.users.AllAsync();

            var roles = await this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();

            return View(new AdminUsersViewModel
            {
                Users = users,
                Roles = roles
            });
        }
       
        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var roleExists =await this.roleManager.RoleExistsAsync(model.Role);
            var userExists = await this.userManager.FindByIdAsync(model.UserId) != null;
            var user = await this.userManager.FindByIdAsync(model.UserId);

            if (!roleExists||!userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details!");
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            await this.userManager.AddToRoleAsync(user, model.Role);

            TempData.AddSuccessMessage($"User {user.UserName} successfully added to role {model.Role}!");

            return RedirectToAction(nameof(Index));
        }

    }
}
