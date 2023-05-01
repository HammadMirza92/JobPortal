using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JobPortal.Services.Repository
{
    public class JobClassRepository : BaseRepository<JobClass>, IJobClassRepository
    {
        private readonly ApplicationDbContext _context;
        public JobClassRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<JobClass>> GetFeatureJobs()
        {
            var allFeatureJobs = await _context.JobClass.Include(x => x.AllJobsClasses)
                 .ThenInclude(c => c.Job)
                 .Where(js => js.name == "Feature" || (js.name == "Urgent" && js.name == "Feature") || (js.name == "Private" && js.name == "Feature")).ToListAsync();
            return allFeatureJobs;
        }
        public async Task<IEnumerable<JobClass>> GetAllJobs()
        {
            var allAllJobs = await _context.JobClass.Include(x=> x.AllJobsClasses)
                .Where(js => js.name != "Feature").ToListAsync();
                    
            
            return allAllJobs;
        }

    }
}
