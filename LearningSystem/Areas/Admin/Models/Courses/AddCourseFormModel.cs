using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Areas.Admin.Models.Courses
{
    public class AddCourseFormModel : IValidatableObject
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name ="Trainer")]
        [Required]
        public string TrainerId  { get; set; }

        public IEnumerable<SelectListItem> Trainers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("The start date can not be in the past!");
            }

            if (this.StartDate > this.EndDate)
            {
                yield return new ValidationResult("The start date must be before the end date!");
            }
        }
    }
}
