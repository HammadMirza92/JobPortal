using JobPortal.Enums;
using JobPortal.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            

            /*Jobs Data*/

            modelBuilder.Entity<Job>().HasData(new Job
            {
                Id = 1,
                Icon = "https://img.freepik.com/premium-vector/gradient-business-investment-logo-design_269830-887.jpg?w=2000",
                Title = "Marketing Manager",
                Description= "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
                Responsibility = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
                Location = Location.Lahore,
                Type = JobType.FullTime,
                Qualifications = Qualification.Bachelor,
                SalaryType = SalaryType.Monthly,
                JobExperience = JobExperience.Oneyear,
                StartBudget = 123,
                EndBudget = 456,
                JobShift = JobShift.Morning,
                JobStatus = JobStatus.Open,
                Vacancy = 20,
                EmployerId =1,
            },
            new Job
            {
                Id = 2,
                Icon = "https://media.istockphoto.com/id/1304359165/vector/motion-data-speed-g-letter-logo-design.jpg?s=612x612&w=0&k=20&c=2A0yYWv8zHhztdShuGoVW87yJZqseV6AKJX0QL2cVuQ=",
                Title = "Software Engineer",
                Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
                Responsibility = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
                Location = Location.Karachi,
                Type = JobType.FullTime,
                Qualifications = Qualification.Bachelor,
                SalaryType = SalaryType.Monthly,
                JobExperience = JobExperience.AboveFive,
                StartBudget = 334,
                EndBudget = 777,
                JobShift = JobShift.Morning,
                JobStatus = JobStatus.Open,
                Vacancy = 5,
                EmployerId = 1,
            },
            new Job
            {

                Id = 3,
                Icon = "https://www.logodesign.net/images/abstract-logo.png",
                Title = "Product Designer",
                Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
                Responsibility = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
                Location = Location.Lahore,
                Type = JobType.PartTime,
                Qualifications = Qualification.Master,
                SalaryType = SalaryType.Monthly,
                JobExperience = JobExperience.Threeyears,
                StartBudget = 190,
                EndBudget = 340,
                JobShift = JobShift.Night,
                JobStatus = JobStatus.Open,
                Vacancy = 50,
                EmployerId = 2,
            });

            /*Roles*/

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id= "1d8bbcb9-6d72-4776-b97a-54dd330775ca",
                Name="admin",
                NormalizedName="ADMIN",
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

           

            /*Identity User*/

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "2fe7daaa-bb2f-43a6-915b-083816e43b87",
                UserName = "employer1@gmail.com",
                FirstName = "Employer 1",
                LastName="first Employer",
                NormalizedUserName = "EMPLOYER1@EMAIL.COM",
                Email = "employer1@gmail.com",
                NormalizedEmail = "EMPLOYER1@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password"),
                EmployeerId=1
            },
            new ApplicationUser
            {
                Id = "088fffd7-94b4-448e-9b67-5619fcf19441",
                UserName = "employer2@gmail.com",
                FirstName = "Employer 2",
                LastName = "Second Employer",
                NormalizedUserName = "EMPLOYER2@EMAIL.COM",
                Email = "employer2@gmail.com",
                NormalizedEmail = "EMPLOYER2@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password"),
                EmployeerId=2
            },
              new ApplicationUser
              {
                  Id = "06e4bc68-0d75-429c-b513-e12c2ab03494",
                  UserName = "employer3@gmail.com",
                  FirstName = "Employer 3",
                  LastName = "Third Employer",
                  NormalizedUserName = "EMPLOYER3@EMAIL.COM",
                  Email = "employer3@gmail.com",
                  NormalizedEmail = "EMPLOYER3@EMAIL.COM",
                  EmailConfirmed = true,
                  PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password"),
                  EmployeerId=3
              },
            new ApplicationUser
            {
                Id = "995ce588-b342-47b8-88f7-349365f898f9",
                UserName = "candidate@gmail.com",
                FirstName = "Candidate 1",
                LastName = "First CAndidate",
                NormalizedUserName = "CANDIDATE1@EMAIL.COM",
                Email = "candidate1@gmail.com",
                NormalizedEmail = "CANDIDATE1@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password")
            },
            new ApplicationUser
            {
                Id = "cc53dc1c-a0d0-49a3-8f31-06b320fe22a9",
                UserName = "candidate2@gmail.com",
                FirstName = "Candidate 2",
                LastName = "Second Candidate",
                NormalizedUserName = "CANDIDATE2@EMAIL.COM",
                Email = "candidate2@gmail.com",
                NormalizedEmail = "CANDIDATE2@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password")
            },
            new ApplicationUser
            {
                Id = "4e9e311a-0926-423c-b136-eab5ba39998a",
                UserName = "candidate3@gmail.com",
                FirstName = "Candidate 3",
                LastName = "third Candidate",
                NormalizedUserName = "CANDIDATE3@EMAIL.COM",
                Email = "candidate3@gmail.com",
                NormalizedEmail = "CANDIDATE3@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password")
            });

            /*User Roles*/

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                UserId = "2fe7daaa-bb2f-43a6-915b-083816e43b87",
                RoleId = "b189a208-8a38-42c5-9922-5dcb918e85c9"
            },
            new IdentityUserRole<string>
            {
                UserId = "088fffd7-94b4-448e-9b67-5619fcf19441",
                RoleId = "b189a208-8a38-42c5-9922-5dcb918e85c9"
            },
            new IdentityUserRole<string>
            {
                UserId = "06e4bc68-0d75-429c-b513-e12c2ab03494",
                RoleId = "b189a208-8a38-42c5-9922-5dcb918e85c9"
            },
            new IdentityUserRole<string>
            {
                UserId = "995ce588-b342-47b8-88f7-349365f898f9",
                RoleId = "7023e28f-c1dc-42cd-ad76-858802f45979"
            },
            new IdentityUserRole<string>
            {
                UserId = "cc53dc1c-a0d0-49a3-8f31-06b320fe22a9",
                RoleId = "7023e28f-c1dc-42cd-ad76-858802f45979"
            },
            new IdentityUserRole<string>
            {
                UserId = "4e9e311a-0926-423c-b136-eab5ba39998a",
                RoleId = "7023e28f-c1dc-42cd-ad76-858802f45979"
            }); 

            /* Employeers Data*/

            modelBuilder.Entity<Employer>().HasData(new Employer
            {
                Id = 1,
                CompanyName = "Avitex Agency",
                CompanyAbout = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.",
                CompanyLogo = "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0",
                Founded = DateTime.UtcNow,
                Headquarters = "Las Vegas, NV 89107, USA",
                Industry = "It",
                CompanyWebsite = "https://jobs.nokriwp.com/",
                CompanySize = 200,
                UserId = "2fe7daaa-bb2f-43a6-915b-083816e43b87"
            },
            new Employer
            {
                Id = 2,
                CompanyName = "Demo 1",
                CompanyAbout = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.",
                CompanyLogo = "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0",
                Founded = DateTime.UtcNow,
                Headquarters = "Lahore",
                Industry = "It",
                CompanyWebsite = "https://jobs.nokriwp.com/",
                CompanySize = 50,
               UserId = "088fffd7-94b4-448e-9b67-5619fcf19441"
            },
            new Employer
            {
                Id = 3,
                CompanyName = "Honda",
                CompanyAbout = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.",
                CompanyLogo = "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0",
                Founded = DateTime.UtcNow,
                Headquarters = "Islamabad",
                Industry = "Machenical",
                CompanyWebsite = "https://jobs.nokriwp.com/",
                CompanySize = 600,
                UserId ="06e4bc68-0d75-429c-b513-e12c2ab03494"
            }) ;

            /*Skills*/

            modelBuilder.Entity<Skills>().HasData(
            new Skills
            {
                Id = 1,
                JobSkill = "Php",
            }, 
            new Skills
            {
                Id = 2,
                JobSkill = "JS",
            },
            new Skills
            {
                Id = 3,
                JobSkill = "Designing",
            },
            new Skills
            {
                Id = 4,
                JobSkill = "Application Development",
            },
            new Skills
            {
                Id = 5,
                JobSkill = "Arts",
            },
            new Skills
            {
                Id = 6,
                JobSkill = ".Net",
            },
            new Skills
            {
                Id = 7,
                JobSkill = "Development",
            },
            new Skills
            {
                Id = 8,
                JobSkill = "Modeling",
            },
            new Skills
            {
                Id = 9,
                JobSkill = "Architecture",
            },
            new Skills
            {
                Id = 10,
                JobSkill = "Management",
            });
 

            /*Candidate Date*/

            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 1,
                Name="Hammad Mirza",
                ProfileImg = "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0",
                AboutMe= "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;",
                Experience= ".Net Developer",
                Phone=03000000,
                Location=Location.Lahore,
                ExperienceTime=5,
                ExpectedSalary = 300,
                Age =23,
                Qualification = Qualification.Bachelor,
                UserId=""
            },
            new Candidate
            {
                Id = 2,
                Name = "Ahtesham",
                ProfileImg = "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0",
                AboutMe = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;",
                Experience = "Php Laravel",
                Phone = 03000000,
                Location = Location.Lahore,
                ExperienceTime = 6,
                ExpectedSalary = 400,
                Age = 23,
                Qualification = Qualification.Bachelor,
                UserId = ""
            },
            new Candidate
            {
                Id = 3,
                Name = "Sohaib",
                ProfileImg = "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0",
                AboutMe = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;",
                Experience = "React Designer",
                Phone = 03000000,
                Location = Location.Islamabad,
                ExperienceTime = 8,
                ExpectedSalary = 500,
                Age = 23,
                Qualification = Qualification.Master,
                UserId = ""
            });


            /*Candidate skills*/
            modelBuilder.Entity<CandidateSkills>().HasData(new CandidateSkills
            {
                Id = 1,
                CandidateId = 1,
                SkillId = 4
            },
            new CandidateSkills
            {
                Id = 2,
                CandidateId = 1,
                SkillId = 6
            },
            new CandidateSkills
            {
                Id = 3,
                CandidateId = 1,
                SkillId = 9
            },
            new CandidateSkills
            {
                Id = 4,
                CandidateId = 2,
                SkillId = 1
            },
            new CandidateSkills
            {
                Id = 5,
                CandidateId = 3,
                SkillId = 3
            },
            new CandidateSkills
            {
                Id = 6,
                CandidateId = 3,
                SkillId = 5
            },
            new CandidateSkills
            {
                Id = 7,
                CandidateId = 3,
                SkillId = 7
            });
         
            /*JobSkils data*/

            modelBuilder.Entity<JobSkills>().HasData(new JobSkills
            {
                Id = 1,
                JobId = 1,
                SkillId = 1,
            },
            new JobSkills
            {
                Id = 2,
                JobId = 1,
                SkillId = 2,
            },
            new JobSkills
            {
                Id = 3,
                JobId = 1,
                SkillId = 3,
            },
            new JobSkills
            {
                Id = 4,
                JobId = 2,
                SkillId = 3,
            },
            new JobSkills
            {
                Id = 5,
                JobId = 2,
                SkillId = 6,
            },
            new JobSkills
            {
                Id = 6,
                JobId = 3,
                SkillId = 6,
            });
          
            /*Job Class*/

            modelBuilder.Entity<JobClass>().HasData(new JobClass
            {
                Id = 1,
               name = "Feature"
            },
            new JobClass
            {
                Id = 2,
                name = "Urgent"
            },
            new JobClass
            {
                Id = 3,
                name = "Private"
            });
   
            /* All Jobs Classes Data*/

            modelBuilder.Entity<AllJobsClasses>().HasData(new AllJobsClasses
            {
                Id = 1,
                JobId = 1,
                JobClassId = 1,
            },
            new AllJobsClasses
            {
                Id = 2,
                JobId = 1,
                JobClassId = 2,
            },
            new AllJobsClasses
            {
                Id = 3,
                JobId = 1,
                JobClassId = 3,
            },
            new AllJobsClasses
            {
                Id = 4,
                JobId = 2,
                JobClassId = 1,
            },
            new AllJobsClasses
            {
                Id = 5,
                JobId = 2,
                JobClassId = 2,
            },
            new AllJobsClasses
            {
                Id = 6,
                JobId = 3,
                JobClassId = 3,
            });
         
        }
              
    }
}
