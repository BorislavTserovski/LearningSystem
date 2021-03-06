﻿using LearningSystem.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin.Contracts
{
   public interface IAdminUserService
    {
       Task<IEnumerable<AdminListingServiceModel>> AllAsync();
    }
}
