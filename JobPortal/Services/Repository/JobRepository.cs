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

        // Get Regular Jobs for Normal Users
        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            var allJobs = await _context.Jobs
                .Where(d => !d.IsDeleted &&
                            (!d.AllJobsClasses.Any(jc =>
                                jc.JobClass.name == JobClasses.Feature ||
                                jc.JobClass.name == JobClasses.Private ||
                                jc.JobClass.name == JobClasses.Urgent)) &&
                            d.DeadLine >= DateTime.Now)
                .Include(x => x.JobSkills)
                .Include(c => c.AllJobsClasses)
                .ThenInclude(jc => jc.JobClass)
                .Include(e=> e.Employer)           
                .ToListAsync();

            return allJobs;
        }

        // Get Feature Jobs for normal Users
        public async Task<IEnumerable<Job>> GetFeatureJobs()
        {
            var allFeatureJobs = await _context.Jobs.Where(d => d.IsDeleted == false).Where(j => j.AllJobsClasses.Any(jc => jc.JobClass.name == JobClasses.Feature || jc.JobClass.name == JobClasses.Private || jc.JobClass.name == JobClasses.Urgent)).Where(de => de.DeadLine >= DateTime.Now)
                .Include(x => x.JobSkills)
                .Include(c => c.AllJobsClasses)
                .ThenInclude(jc => jc.JobClass)
                .Include(e => e.Employer)
                .ToListAsync();

            return allFeatureJobs;
        }

        // Get Regular Jobs of candidate
        public async Task<IEnumerable<Job>> GetAllJobs(Guid id)
        {
            var allJobs = await _context.Jobs.Where(d => d.IsDeleted == false).Where(aj => !aj.AppliedJobs.Any(a => a.CandidateId == id)).Where(j => !j.AllJobsClasses.Any(jc => jc.JobClass.name == JobClasses.Feature || jc.JobClass.name == JobClasses.Private || jc.JobClass.name == JobClasses.Urgent) || j.AllJobsClasses == null).Where(de=> de.DeadLine >= DateTime.Now)
               .Include(x => x.JobSkills)
               .Include(c => c.AllJobsClasses)
               .ThenInclude(jc => jc.JobClass)
               .Include(e => e.Employer)
               .ToListAsync();

            return allJobs;
        }

        // Get Feature Jobs of candidate
        public async Task<IEnumerable<Job>> GetFeatureJobs(Guid id)
        {
            var allFeatureJobs = await _context.Jobs.Where(d => d.IsDeleted == false).Where(aj =>!aj.AppliedJobs.Any(a => a.CandidateId == id)).Where(j => j.AllJobsClasses.Any(jc => jc.JobClass.name == JobClasses.Feature || jc.JobClass.name == JobClasses.Private || jc.JobClass.name == JobClasses.Urgent)).Where(de => de.DeadLine >= DateTime.Now)
                .Include(x => x.JobSkills)
                .Include(c => c.AllJobsClasses)
                .ThenInclude(jc => jc.JobClass)
                .Include(e => e.Employer)
                .ToListAsync();

            return allFeatureJobs;
        }

        // Get Job By Id and include JobSkills, AllJobsClasses, Employer
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

        // Fetch AppliedJobs of Company
        public async Task<IEnumerable<AppliedJobs>> FetchJobApplied(Guid id)
        {
            var jobByEmployerId = await _context.Jobs.Where(d => d.IsDeleted == false).Where(x => x.EmployerId == id).Include(aj=> aj.AppliedJobs).ThenInclude(c=> c.Candidate).ToListAsync();
            var appliedJobs = jobByEmployerId.SelectMany(j => j.AppliedJobs).ToList();
            return appliedJobs;
        }

        // Filter Job on the basis of Title, Location, Type, Qualification, SalaryType, StartBudget, EndBudget, JobExperience, JobShift, JobClass
        public async Task<IEnumerable<Job>> FilterJobs(SearchJobs searchJobs)
        {
            var result = await _context.Jobs.Include(jc => jc.AllJobsClasses).ThenInclude(x => x.JobClass).Include(e=> e.Employer)
                .Where(x =>
                (string.IsNullOrEmpty(searchJobs.Title) || x.Title.Contains(searchJobs.Title)) &&
                (searchJobs.Location == null || x.Location == searchJobs.Location) &&
                (searchJobs.Type == null || x.Type == searchJobs.Type) &&
                (searchJobs.Qualification == null || x.Qualifications == searchJobs.Qualification) &&
                (searchJobs.SalaryType == null || x.SalaryType == searchJobs.SalaryType) &&
                (searchJobs.StartBudget == null || x.StartBudget >= searchJobs.StartBudget) &&
                (searchJobs.EndBudget == null || x.EndBudget <= searchJobs.EndBudget) &&
                (searchJobs.JobExperience == null || x.JobExperience == searchJobs.JobExperience) &&
                (searchJobs.JobShift == null || x.JobShift == searchJobs.JobShift)&&
                (searchJobs.JobClass == null || x.AllJobsClasses.Any(x=> x.JobClass.name == searchJobs.JobClass))).ToListAsync();

            return result;
        }
    }
}
