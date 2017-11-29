using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Models.Home
{
    public class SearchFormModel
    {
        public string SearchText { get; set; }

        [Display(Name = "Search in users")]
        public bool SearchInUsers { get; set; } = true;

        [Display(Name = "Search in courses")]
        public bool SearchInCourses { get; set; } = true;
    }
}
