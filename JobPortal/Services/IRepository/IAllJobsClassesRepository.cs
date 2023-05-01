using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository.Base;

namespace JobPortal.Services.IRepository
{
    public interface IAllJobsClassesRepository : IBaseRepository<AllJobsClasses>
    {
        Task<IEnumerable<AllJobsClasses>> GetFeatureJobs();
        Task<IEnumerable<AllJobsClasses>> GetAllJobs();
    }
}
