using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Data.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public List<Course> Trainings { get; set; } = new List<Course>();

        public List<StudentCourse> Courses { get; set; } = new List<StudentCourse>();

        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
