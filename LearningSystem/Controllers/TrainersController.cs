using LearningSystem.Data.Models;
using LearningSystem.Models.Trainer;
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
    [Authorize(Roles = WebConstants.TrainerRole)]
    public class TrainersController : Controller
    {
        private readonly ICourseService courses;
        private readonly ITrainerService trainers;
        private readonly UserManager<User> userManager;
        public TrainersController(ITrainerService trainers,
            UserManager<User> userManager,
            ICourseService courses)
        {
            this.courses = courses;
            this.trainers = trainers;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Courses()
        {
            var userId = this.userManager.GetUserId(User);

            var courses = await this.trainers.ByTrainer(userId);

            return View(courses);
        }

        public async Task<IActionResult> Students(int id)
        {
            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainer(id, userId))
            {
                return NotFound();
            }

            var students = await this.trainers.StudentsInCourseAsync(id);

            return View(new StudentsInCourseViewModel
            {
                Students = students,
                Course = await this.courses.ByIdAsync<CourseListingServiceModel>(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult>GradeStudent(int id, string studentId, Grade grade)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest();
            }
            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainer(id, userId))
            {
                return BadRequest();
            }

            var success = await this.trainers.AddGrade(id, studentId, grade);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Students), new {id} );
        }
    }
}
