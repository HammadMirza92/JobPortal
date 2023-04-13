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
        public async Task<IEnumerable<Job>> FilterJob(string Title, JobStatus Status, JobType Type, double StartBudget, double EndBudget, int Vacancy, string Location, DateTime StartDate, DateTime EndDate)
        {
            var result = await _context.Jobs
                .Where(x =>
                (string.IsNullOrEmpty(Title) || x.Title.Contains(Title) )&&
                (x.Status == Status) && ( x.Type == Type) &&
                (StartBudget == 0|| x.StartBudget >= StartBudget) &&
                (EndBudget == 0|| x.EndBudget <= EndBudget) &&
                (Vacancy == 0|| x.Vacancy >= Vacancy) &&
                (string.IsNullOrEmpty(Location) || x.Location.Contains(Location)) &&
                (StartDate == DateTime.MinValue || x.StartDate >= StartDate) &&
                (EndDate == DateTime.MinValue || x.EndDate <= EndDate)).ToListAsync();
            return result;
        }
    }
}
