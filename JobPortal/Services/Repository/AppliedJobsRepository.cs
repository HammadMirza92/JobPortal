using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services.Repository
{
    public class AppliedJobsRepository : BaseRepository<AppliedJobs>, IAppliedJobsRepository
    {
        private readonly ApplicationDbContext _context;
        public AppliedJobsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<AppliedJobs>> GetJobByCandidateId(int id)
        {
            var allAppliedJobsofCandidate = await _context.AppliedJobs.Where(x=> x.CandidateId == id)
                .Include(j=> j.Job)
                .Include(c=> c.Candidate)
                .ToListAsync();
            return allAppliedJobsofCandidate;
        }
       
    }
}
