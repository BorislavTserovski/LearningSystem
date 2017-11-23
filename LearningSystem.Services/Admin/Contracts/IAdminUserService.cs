using LearningSystem.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Admin.Contracts
{
   public interface IAdminUserService
    {
        IEnumerable<AdminListingServiceModel> All();
    }
}
