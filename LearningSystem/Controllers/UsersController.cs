﻿using LearningSystem.Data.Models;
using LearningSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Controllers
{
    public class UsersController : Controller
    {
        private IUserService users;
        private UserManager<User> userManager;

        public UsersController(IUserService users,
            UserManager<User> userManager)
        {
            this.users = users;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Profile(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }
            var profile = await this.users.ProfileAsync(user.Id);
            return View(profile);
        }
    }
}
