using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services.Repository
{
    public class EmployerRepository : BaseRepository<Employer>, IEmployerRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Employer>> GetAll()
        {
            var allEmployeers = await _context.Employer
               .Include(x => x.JobOffered)
               .ToListAsync();

            return allEmployeers;
        }
        public override async Task<Employer> GetById(Guid id)
        {
            var employeer = await _context.Employer
                .Include(x => x.JobOffered).Where(d => d.IsDeleted == false)
                 .Include(x => x.JobOffered)
                .ThenInclude(aj => aj.AppliedJobs)
                .Include(x => x.JobOffered)
                .ThenInclude(x=> x.AllJobsClasses)
                .ThenInclude(x=> x.JobClass).Where(x=> x.Id == id).FirstOrDefaultAsync();
            return employeer;
        }

        public async Task<IEnumerable<Employer>> FilterEmployer(SearchEmployer searchEmployer)
        {
            var result = await _context.Employer
                .Where(x =>
                (string.IsNullOrEmpty(searchEmployer.EmployerName) || x.CompanyName.Contains(searchEmployer.EmployerName)) &&
                (string.IsNullOrEmpty(searchEmployer.Headquarters) || x.Headquarters.Contains(searchEmployer.Headquarters))).ToListAsync();

            return result;
        }
    }
}
