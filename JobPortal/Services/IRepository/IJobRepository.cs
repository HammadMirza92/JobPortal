using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository.Base;

namespace JobPortal.Services.IRepository
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        Task<IEnumerable<Job>> FilterJob(string Title, JobStatus Status, JobType Type, double StartBudget, double EndBudget, int Vacancy, Location Location, DateTime StartDate, DateTime EndDate);
        Task<IEnumerable<Job>> GetFeatureJobs(Guid id);
        Task<IEnumerable<Job>> GetFeatureJobs();
        Task<IEnumerable<Job>> GetAllJobs(Guid id);
        Task<IEnumerable<AppliedJobs>> FetchJobApplied(Guid id);
    }
}
