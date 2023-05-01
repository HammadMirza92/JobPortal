﻿using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository.Base;

namespace JobPortal.Services.IRepository
{
    public interface IJobSkillsRepository : IBaseRepository<JobSkills>
    {
        Task<IEnumerable<JobSkills>> GetFeatureJobs();
    }
}
