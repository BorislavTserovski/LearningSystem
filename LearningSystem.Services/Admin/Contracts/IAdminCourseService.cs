﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin.Contracts
{
    public interface IAdminCourseService
    {
        Task Create(string name, string description, DateTime startDate, DateTime endDate, string trainerId);
    }
}
