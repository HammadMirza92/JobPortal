using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services.Repository
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        private readonly ApplicationDbContext _context;
        public JobRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Job>> GetAll()
        {
            var allJobs = await _context.Jobs.Include(x => x.JobSkills).Include(c => c.AllJobsClasses).ThenInclude(jc => jc.JobClass).ToListAsync();
            return allJobs;
        }
        public async Task<IEnumerable<Job>> GetFeatureJobs()
        {
            var allFeatureJobs = await _context.Jobs.Include(x => x.JobSkills).Include(c=> c.AllJobsClasses).ThenInclude(jc=>jc.JobClass).ToListAsync();
            return allFeatureJobs;
        }
        public async Task<IEnumerable<Job>> FilterJob(string Title, JobStatus Status, JobType Type, double StartBudget, double EndBudget, int Vacancy, Location Location, DateTime StartDate, DateTime EndDate)
        {
            var result = await _context.Jobs
                .Where(x =>
                (string.IsNullOrEmpty(Title) || x.Title.Contains(Title) )&&
                ( x.Type == Type) &&
                (StartBudget == 0|| x.StartBudget >= StartBudget) &&
                (EndBudget == 0|| x.EndBudget <= EndBudget) &&
                (Vacancy == 0|| x.Vacancy >= Vacancy)).ToListAsync();
            return result;
        }
    }
}
