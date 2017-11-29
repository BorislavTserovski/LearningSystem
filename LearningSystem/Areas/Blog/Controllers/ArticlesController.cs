using LearningSystem.Areas.Blog.Models.Articles;
using LearningSystem.Data.Models;
using LearningSystem.Infrastructure.Extensions;
using LearningSystem.Services.Blog;
using LearningSystem.Services.Html;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Areas.Blog.Controllers
{
    [Area(WebConstants.BlogArea)]
    [Authorize(Roles = WebConstants.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IHtmlService html;
        private readonly IBlogArticleService articles;
        private readonly UserManager<User> userManager;

        public ArticlesController(IHtmlService html, IBlogArticleService articles, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.articles = articles;
            this.html = html;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        => View(new ArticleListingViewModel
        {
            Articles = await this.articles.AllAsync(page),
            TotalArticles = await this.articles.TotalAsync(),
            CurrentPage = page

        });

        public async Task<IActionResult> Details(int id)
        => this.ViewOrNotFound(await this.articles.ById(id));
        
        

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(PublishArticleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Content = this.html.Sanitize(model.Content);
            var userId = this.userManager.GetUserId(User);
            await this.articles.CreateAsync(model.Title, model.Content, userId);

            return RedirectToAction(nameof(Index));

        }
    }
}
