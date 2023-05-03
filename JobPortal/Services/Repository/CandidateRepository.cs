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
               .Include(x => x.CandidateSkills)
               .ToListAsync();

            return allJobs;
        }
    }
}
