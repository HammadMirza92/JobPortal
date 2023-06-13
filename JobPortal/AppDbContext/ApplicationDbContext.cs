using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Models.ModelBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static IdentityServer4.Models.IdentityResources;

namespace JobPortal.AppDbContext
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
          
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<JobSkills> JobSkills { get; set; }
        public DbSet<AllJobsClasses> AllJobsClasses { get; set; }
        public DbSet<JobClass> JobClass { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<CandidateSkills> CandidateSkills { get; set; }
        public DbSet<AppliedJobs> AppliedJobs { get; set; }
        public DbSet<SendEmail> SendEmail { get; set; }
        public DbSet<EmployerToCandidateEmail> EmployerToCandidateEmail { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);

            /*Roles*/

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1d8bbcb9-6d72-4776-b97a-54dd330775ca",
                Name = "admin",
                NormalizedName = "ADMIN",
            },
            new IdentityRole
            {
                Id = "7023e28f-c1dc-42cd-ad76-858802f45979",
                Name = "candidate",
                NormalizedName = "CANDIDATE",
            },
            new IdentityRole
            {
                Id = "b189a208-8a38-42c5-9922-5dcb918e85c9",
                Name = "employer",
                NormalizedName = "EMPLOYER",
            });
                      

            /*Skills*/

            modelBuilder.Entity<Skills>().HasData(
            new Skills
            {
                Id = Guid.Parse("aafbde46-32ee-45bd-b52a-a76a1ac12a78"),
                JobSkill = "Php",
            }, 
            new Skills
            {
                Id = Guid.Parse("bae33518-8dc8-4d53-80ca-e8f58a9fd808"),
                JobSkill = "JS",
            },
            new Skills
            {
                Id = Guid.Parse("0b886a97-0b5a-44e0-b1a9-c1ddecb67f2d"),
                JobSkill = "Designing",
            },
            new Skills
            {
                Id = Guid.Parse("9a126650-2936-442e-92ba-7d7dc32ff6f9"),
                JobSkill = "React Native",
            },
            new Skills
            {
                Id = Guid.Parse("83c89321-daf9-4ade-b229-d57615a32f10"),
                JobSkill = "Arts",
            },
            new Skills
            {
                Id = Guid.Parse("010039fb-a687-4db5-8ada-3b586d3a4788"),
                JobSkill = ".Net",
            },
            new Skills
            {
                Id = Guid.Parse("2dd27837-b570-4c81-8bfc-bf8cad8323b6"),
                JobSkill = "Java",
            },
            new Skills
            {
                Id = Guid.Parse("e4599076-fa12-4fe9-a8e4-35130d73729e"),
                JobSkill = "MERN Stack",
            },
            new Skills
            {
                Id = Guid.Parse("b749f4b8-3bc3-4a05-816b-56e0d12dfaaa"),
                JobSkill = "Architecture",
            },
            new Skills
            {
                Id = Guid.Parse("f235f414-fc41-4acb-a1ee-1fd79aea7eae"),
                JobSkill = "Management",
            });
          
            /*Job Class*/

            modelBuilder.Entity<JobClass>().HasData(new JobClass
            {
                Id = Guid.Parse("642a9e91-5c4a-4284-aa0f-69e39a93ea6d"),
                name = JobClasses.Feature
            },
            new JobClass
            {
                Id = Guid.Parse("63acd142-d323-42c5-a453-1b67f40fd073"),
                name = JobClasses.Urgent
            },
            new JobClass
            {
                Id = Guid.Parse("930c379d-d9e6-4a48-82b0-4f586d6aafc8"),
                name = JobClasses.Private
            });
   
        }
              
    }
}
