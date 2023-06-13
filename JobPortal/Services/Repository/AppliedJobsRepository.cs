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

        public override async Task<IEnumerable<AppliedJobs>> GetAll()
        {
            var allAppliedJobs = await _context.AppliedJobs
                .Where(d => !d.IsDeleted)
                .Include(x => x.Job).ThenInclude(emp=> emp.Employer)
                .Include(c => c.Candidate)
                .ToListAsync();

            return allAppliedJobs;
        }
        // fetch Jobs In which Candidate applied
        public async Task<IEnumerable<AppliedJobs>> GetJobByCandidateId(Guid id)
        {
            var allAppliedJobsofCandidate = await _context.AppliedJobs.Where(x=> x.CandidateId == id)
                .Include(j=> j.Job)
                .ThenInclude(ac=>ac.AllJobsClasses).ThenInclude(jc=> jc.JobClass)
                .Include(c=> c.Candidate)
                .ToListAsync();
            return allAppliedJobsofCandidate;
        }
       
    }
}
