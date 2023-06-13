using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Models.ModelBase;
using JobPortal.Services.IRepository.Base;

namespace JobPortal.Services.IRepository
{
    public interface ICSVRepository 
    {
        Task<string> CandidateCSV(IEnumerable<Candidate> candidate);
        Task<string> EmployerCSV(IEnumerable<Employer> employer);
        Task<string> AppliedJobsCSV(IEnumerable<AppliedJobs> appliedJobs);
        Task<string> JobsCSV(List<Job> job);
    }
}
