using LearningSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> Active();

        Task<TModel> ByIdAsync<TModel>(int id) where TModel : class;

        Task<IEnumerable<CourseListingServiceModel>> FindAsync(string serchText);

       Task<bool> SignInUser(int courseId, string userId);

        Task<bool> UserIsSignedInCourse(int courseId, string userId);

        Task<bool> SignOutUser(int id, string userId);
    }
}
