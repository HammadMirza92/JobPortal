using JobPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.AppDbContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Job> Jobs { get; set; }
    }
}
