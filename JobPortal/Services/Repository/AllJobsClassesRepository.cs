using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Models.ModelBase;
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
       
       

    }
}
