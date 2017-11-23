using System;
using System.Collections.Generic;
using System.Text;
using LearningSystem.Services.Admin.Models;
using LearningSystem.Services.Admin.Contracts;
using LearningSystem.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace LearningSystem.Services.Admin.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly LearningSystemDbContext db;

        public AdminUserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminListingServiceModel> All()
        => this.db
            .Users
            .ProjectTo<AdminListingServiceModel>()
            .ToList();
    }
}
