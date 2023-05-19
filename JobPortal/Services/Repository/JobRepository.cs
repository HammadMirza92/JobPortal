using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.Linq;

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
            var allJobs = await _context.Jobs.Where(d => d.IsDeleted == false).Where(j => !j.AllJobsClasses.Any(jc => jc.JobClass.name == JobClasses.Feature) || j.AllJobsClasses == null).Where(de => de.DeadLine >= DateTime.Now)
               .Include(x => x.JobSkills)
               .Include(c => c.AllJobsClasses)
               .ThenInclude(jc => jc.JobClass)
               .ToListAsync();

            return allJobs;
        }
        public async Task<IEnumerable<Job>> GetFeatureJobs()
        {
            var allFeatureJobs = await _context.Jobs.Where(d => d.IsDeleted == false).Where(j => j.AllJobsClasses.Any(jc => jc.JobClass.name == JobClasses.Feature)).Where(de => de.DeadLine >= DateTime.Now)
                .Include(x => x.JobSkills)
                .Include(c => c.AllJobsClasses)
                .ThenInclude(jc => jc.JobClass)
                .ToListAsync();

            return allFeatureJobs;
        }
        public async Task<IEnumerable<Job>> GetAllJobs(Guid id)
        {
            var allJobs = await _context.Jobs.Where(d => d.IsDeleted == false).Where(aj => !aj.AppliedJobs.Any(a => a.CandidateId == id)).Where(j => !j.AllJobsClasses.Any(jc => jc.JobClass.name == JobClasses.Feature) || j.AllJobsClasses == null).Where(de=> de.DeadLine >= DateTime.Now)
               .Include(x => x.JobSkills)
               .Include(c => c.AllJobsClasses)
               .ThenInclude(jc => jc.JobClass)
               .ToListAsync();

            return allJobs;
        }
        public async Task<IEnumerable<Job>> GetFeatureJobs(Guid id)
        {
            var allFeatureJobs = await _context.Jobs.Where(d => d.IsDeleted == false).Where(aj =>!aj.AppliedJobs.Any(a => a.CandidateId == id)).Where(j => j.AllJobsClasses.Any(jc => jc.JobClass.name == JobClasses.Feature)).Where(de => de.DeadLine >= DateTime.Now)
                .Include(x => x.JobSkills)
                .Include(c => c.AllJobsClasses)
                .ThenInclude(jc => jc.JobClass)
                .ToListAsync();

            return allFeatureJobs;
        }
        public override async Task<Job> GetById(Guid id)
        {
            var jobById = await _context.Jobs.Where(d => d.IsDeleted == false).Include(aj => aj.AppliedJobs)
                .Include(x => x.JobSkills)
                .ThenInclude(s=> s.Skill)
                .Include(c => c.AllJobsClasses)
                .ThenInclude(jc => jc.JobClass)
                .Include(e => e.Employer).FirstOrDefaultAsync(j => j.Id == id);

            return jobById;
        }
        public async Task<IEnumerable<AppliedJobs>> FetchJobApplied(Guid id)
        {
            var jobById = await _context.Jobs.Where(d => d.IsDeleted == false).Where(d => !d.IsDeleted).Where(x => x.EmployerId == id).Include(aj=> aj.AppliedJobs).ThenInclude(c=> c.Candidate).ToListAsync();
            var appliedJobs = jobById.SelectMany(j => j.AppliedJobs).ToList();
            return appliedJobs;
        }
        public async Task<IEnumerable<Job>> FilterJob(string Title, JobStatus Status, JobType Type, double StartBudget, double EndBudget, int Vacancy, Location Location, DateTime StartDate, DateTime EndDate)
        {
            var result = await _context.Jobs
                .Where(x =>
                (string.IsNullOrEmpty(Title) || x.Title.Contains(Title)) &&
                (x.Type == Type) &&
                (StartBudget == 0 || x.StartBudget >= StartBudget) &&
                (EndBudget == 0 || x.EndBudget <= EndBudget) &&
                (Vacancy == 0 || x.Vacancy >= Vacancy)).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Job>> FilterJobs(SearchJobs searchJobs)
        {
            var result = await _context.Jobs.Include(jc => jc.AllJobsClasses).ThenInclude(x => x.JobClass)
                .Where(x =>
                (string.IsNullOrEmpty(searchJobs.Title) || x.Title.Contains(searchJobs.Title)) &&
                (searchJobs.Location == null || x.Location == searchJobs.Location) &&
                 (searchJobs.Type == null || x.Type == searchJobs.Type) &&
                  (searchJobs.Qualification == null || x.Qualifications == searchJobs.Qualification) &&
                   (searchJobs.SalaryType == null || x.SalaryType == searchJobs.SalaryType) &&
                    (searchJobs.StartBudget == null || x.StartBudget >= searchJobs.StartBudget) &&
                     (searchJobs.EndBudget == null || x.EndBudget <= searchJobs.EndBudget) &&
                      (searchJobs.JobExperience == null || x.JobExperience == searchJobs.JobExperience) &&
                      (searchJobs.JobShift == null || x.JobShift == searchJobs.JobShift)).ToListAsync();
                      // (searchJobs.JobShift == null || x.AllJobsClasses.Any(x=> x.JobClass.name) == searchJobs.JobShift)).ToListAsync();

            return result;
        }
    }
}
