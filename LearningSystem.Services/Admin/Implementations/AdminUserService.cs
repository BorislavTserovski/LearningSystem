using System;
using System.Collections.Generic;
using System.Text;
using LearningSystem.Services.Admin.Models;
using LearningSystem.Services.Admin.Contracts;
using LearningSystem.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Services.Admin.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly LearningSystemDbContext db;

        public AdminUserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminListingServiceModel>> AllAsync()
        =>  await this.db
            .Users
            .ProjectTo<AdminListingServiceModel>()
            .ToListAsync();
    }
}
