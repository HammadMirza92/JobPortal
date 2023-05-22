using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository.Base;

namespace JobPortal.Services.IRepository
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        Task<IEnumerable<Job>> GetFeatureJobs(Guid id);
        Task<IEnumerable<Job>> GetFeatureJobs();
        Task<IEnumerable<Job>> GetAllJobs(Guid id);
        Task<IEnumerable<AppliedJobs>> FetchJobApplied(Guid id);
        Task<IEnumerable<Job>> FilterJobs(SearchJobs searchJobs);
    }
}
