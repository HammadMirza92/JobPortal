using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services.Repository
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        private readonly ApplicationDbContext _context;
        public CandidateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Candidate>> GetAll()
        {
            var allJobs = await _context.Candidate
               .Include(x => x.CandidateSkills).ThenInclude(s=> s.Skills)
               .ToListAsync();

            return allJobs;
        }
        public override async Task<Candidate> GetById(Guid id)
        {
            var jobById = await _context.Candidate
                .Include(aJ => aJ.AppliedJobs).ThenInclude(j=> j.Job)
                .Include(cs=> cs.CandidateSkills)
                .FirstOrDefaultAsync();

            return jobById;
        }
    }
}
