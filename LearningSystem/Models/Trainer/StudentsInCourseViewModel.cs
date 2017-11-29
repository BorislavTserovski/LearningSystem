using LearningSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Models.Trainer
{
    public class StudentsInCourseViewModel
    {
        public IEnumerable<StudentsInCourseModel> Students { get; set; }

        public CourseListingServiceModel Course { get; set; }
    }
}
