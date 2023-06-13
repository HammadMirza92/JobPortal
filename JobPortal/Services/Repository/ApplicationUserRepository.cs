using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services.Repository
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Get User By Email
        public async Task<ApplicationUser> FindUserByEmail(string email)
        {
            var user = await _context.ApplicationUsers.Where(x => x.Email == email).FirstOrDefaultAsync();

            return user;
        }

        // Get User By Id
        public async Task<ApplicationUser> GetById(string id)
        {
            var appuser = await _context.ApplicationUsers.FindAsync(id);
            return appuser;
        }
    }
}
