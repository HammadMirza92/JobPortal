using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services.Repository
{
    public class EmployerToCandidateEmailRepository : BaseRepository<EmployerToCandidateEmailRepository>, IEmployerToCandidateEmailRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployerToCandidateEmailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}