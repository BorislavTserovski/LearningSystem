﻿using LearningSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Models.Home
{
    public class HomeIndexViewModel : SearchFormModel
    {
        public IEnumerable<CourseListingServiceModel> Courses { get; set; }

       


    }
}
