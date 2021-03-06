﻿using LearningSystem.Data.Models;
using LearningSystem.Infrastructure.Extensions;
using LearningSystem.Models.Courses;
using LearningSystem.Services;
using LearningSystem.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService courses;
        private readonly UserManager<User> userManager;

        public CoursesController(ICourseService courses, UserManager<User> userManager)
        {
            this.courses = courses;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new CourseDetailsViewModel
            {
                Course = await this.courses.ByIdAsync<CourseDetailsServiceModel>(id)
            };
            if (model.Course==null)
            {
                return NotFound();
            }
           
            if (User.Identity.IsAuthenticated)
            {
                var userId = this.userManager.GetUserId(User);
                var userIsSigned = this.courses.UserIsSignedInCourse(id, userId);
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignIn(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var success = await this.courses.SignInUser(id, userId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("Thank you for your registration!");

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignOut(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var success = await this.courses.SignOutUser(id, userId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("Sorry to see you go!");

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
