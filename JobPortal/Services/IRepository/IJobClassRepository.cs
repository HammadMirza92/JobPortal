using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository.Base;

namespace JobPortal.Services.IRepository
{
    public interface IJobClassRepository : IBaseRepository<JobClass>
    {
        Task<IEnumerable<JobClass>> GetFeatureJobs();
        Task<IEnumerable<JobClass>> GetAllJobs();
    }
}
