using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository.Base;

namespace JobPortal.Services.IRepository
{
    public interface IAppliedJobsRepository : IBaseRepository<AppliedJobs>
    {
        Task<IEnumerable<AppliedJobs>> GetJobByCandidateId(Guid id);
    }
}
