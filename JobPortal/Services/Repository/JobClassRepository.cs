using JobPortal.AppDbContext;
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
       
       

    }
}
