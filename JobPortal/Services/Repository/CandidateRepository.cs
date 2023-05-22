using IdentityServer4.Extensions;
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

        // Get All Candidates
        public override async Task<IEnumerable<Candidate>> GetAll()
        {
            var allJobs = await _context.Candidate
               .Include(x => x.CandidateSkills).ThenInclude(s=> s.Skills)
               .ToListAsync();

            return allJobs;
        }

        // Get Candidate By Id
        public override async Task<Candidate> GetById(Guid id)
        {
            var jobById = await _context.Candidate.Where(c=> c.Id==id)
                .Include(aJ => aJ.AppliedJobs).ThenInclude(j=> j.Job).ThenInclude(e=> e.Employer)
                .Include(cs=> cs.CandidateSkills)
                .FirstOrDefaultAsync();

            return jobById;
        }

        // Filter Candidate
        public async Task<IEnumerable<Candidate>> FilterCandidate(SearchCandidate searchCandidate)
        {
            var result = await _context.Candidate
                .Where(x =>
                (string.IsNullOrEmpty(searchCandidate.CandidateName) || x.Name.Contains(searchCandidate.CandidateName)) &&
                (string.IsNullOrEmpty(searchCandidate.CandiadteField) || x.Experience.Contains(searchCandidate.CandiadteField))&&
                (searchCandidate.Location == null || x.Location == searchCandidate.Location)).ToListAsync();

            return result;
        }
    }
}
