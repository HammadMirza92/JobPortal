using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services.Repository
{
    public class CandidateSkillsRepository : BaseRepository<CandidateSkills>, ICandidateSkillsRepository
    {
        private readonly ApplicationDbContext _context;
        public CandidateSkillsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
       
     
    }
}
