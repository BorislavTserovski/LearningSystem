using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LearningSystem.Models;
using LearningSystem.Services;
using System.Threading.Tasks;
using LearningSystem.Models.Home;

namespace LearningSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService courses;
        private readonly IUserService users;

        public HomeController(ICourseService courses,
            IUserService users)
        {
            this.courses = courses;
            this.users = users;
        }

        public async Task<IActionResult> Index()
        => View(new HomeIndexViewModel
        {
            Courses = await this.courses.Active()
        });

        public async Task<IActionResult> Search(SearchFormModel model)
        {
            var viewModel = new SearchViewModel
            {
                SearchText = model.SearchText
            };

            if (model.SearchInCourses)
            {
                viewModel.Courses = await this.courses.FindAsync(viewModel.SearchText);
            }

            if (model.SearchInUsers)
            {
                viewModel.Users = await this.users.FindAsync(model.SearchText);
            }
            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
