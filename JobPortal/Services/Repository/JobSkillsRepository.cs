using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services.Repository
{
    public class JobSkillsRepository : BaseRepository<JobSkills>, IJobSkillsRepository
    {
        private readonly ApplicationDbContext _context;
        public JobSkillsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<JobSkills>> GetFeatureJobs()
        {
            var allFeatureJobs = await _context.JobSkills.Include(c=> c.Job).ToListAsync();
            return allFeatureJobs;
        }
       
    }
}
