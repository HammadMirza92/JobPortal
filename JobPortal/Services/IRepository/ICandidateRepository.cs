using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository.Base;

namespace JobPortal.Services.IRepository
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        Task<IEnumerable<Candidate>> FilterCandidate(SearchCandidate searchCandidate);
    }
}
