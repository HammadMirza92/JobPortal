using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JobPortal.Services.Repository
{
    public class AllJobsClassesRepository : BaseRepository<AllJobsClasses>, IAllJobsClassesRepository
    {
        private readonly ApplicationDbContext _context;
        public AllJobsClassesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<AllJobsClasses>> GetFeatureJobs()
        {
            var allFeatureJobs = await _context.AllJobsClasses.Include(x => x.JobClass).Include(j=> j.Job).ToListAsync();
            return allFeatureJobs;
        }
        public async Task<IEnumerable<AllJobsClasses>> GetAllJobs()
        {
            var allAllJobs =  await _context.AllJobsClasses.Include(x=> x.JobClass).Include(x=> x.Job).Where(x=> x.JobClassId != 1).ToListAsync();
                    
            
            return allAllJobs;
        }

    }
}
