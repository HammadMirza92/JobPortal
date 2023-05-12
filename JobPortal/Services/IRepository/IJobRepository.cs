using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository.Base;

namespace JobPortal.Services.IRepository
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        Task<IEnumerable<Job>> FilterJob(string Title, JobStatus Status, JobType Type, double StartBudget, double EndBudget, int Vacancy, Location Location, DateTime StartDate, DateTime EndDate);
        Task<IEnumerable<Job>> GetFeatureJobs(int id);
    }
}
