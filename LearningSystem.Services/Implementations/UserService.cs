using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Services.Models;
using LearningSystem.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;

        public UserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText)
       => await this.db.Users
            .OrderByDescending(c => c.UserName)
            .Where(u => u.UserName.ToLower().Contains(searchText.ToLower()))
            .ProjectTo<UserListingServiceModel>()
            .ToListAsync();
        public async Task<UserProfileServiceModel> ProfileAsync(string id)
      => await this.db
            .Users
            .Where(u => u.Id == id)
            .ProjectTo<UserProfileServiceModel>(new { userId = id})
            .FirstOrDefaultAsync();
            
           
    }
}
