﻿using LearningSystem.Services;
using LearningSystem.Services.Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Areas.Blog.Models.Articles
{
    public class ArticleListingViewModel
    {
        public IEnumerable<BlogArticleListingServiceModel> Articles { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalArticles / ServiceConstants.BlogArticlePageSize);

        public int NextPage
            => this.CurrentPage ==this.TotalPages
            ? this.TotalPages
            : this.CurrentPage + 1;

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int TotalArticles { get; set; }
    }
}
