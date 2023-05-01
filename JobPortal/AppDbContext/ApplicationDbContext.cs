using JobPortal.Enums;
using JobPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<Employeer> Employeer { get; set; }
        public DbSet<CandidateSkills> CandidateSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                EmployeerId =1,
            });
            modelBuilder.Entity<Job>().HasData(new Job
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
                EmployeerId = 1,
            });
            modelBuilder.Entity<Job>().HasData(new Job
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
                JobExperience = JobExperience.Threeyear,
                StartBudget = 190,
                EndBudget = 340,
                JobShift = JobShift.Night,
                JobStatus = JobStatus.Open,
                Vacancy = 50,
                EmployeerId = 2,
            });




            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id= "1d8bbcb9-6d72-4776-b97a-54dd330775ca",
                Name="admin",
                NormalizedName="ADMIN",
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "7023e28f-c1dc-42cd-ad76-858802f45979",
                Name = "user",
                NormalizedName = "USER",
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2fe7daaa-bb2f-43a6-915b-083816e43b87",
                Name = "company",
                NormalizedName = "COMPANY",
            });





            modelBuilder.Entity<Skills>().HasData(new Skills
            {
                Id = 1,
                JobSkill = "Php",
            });
            modelBuilder.Entity<Skills>().HasData(new Skills
            {
                Id = 2,
                JobSkill = "JS",
            });
            modelBuilder.Entity<Skills>().HasData(new Skills
            {
                Id = 3,
                JobSkill = "Designing",
            });
            modelBuilder.Entity<Skills>().HasData(new Skills
            {
                Id = 4,
                JobSkill = "Application Development",
            });
            modelBuilder.Entity<Skills>().HasData(new Skills
            {
                Id = 5,
                JobSkill = "Arts",
            });
            modelBuilder.Entity<Skills>().HasData(new Skills
            {
                Id = 6,
                JobSkill = "Painting",
            });
            modelBuilder.Entity<Skills>().HasData(new Skills
            {
                Id = 7,
                JobSkill = "Development",
            });
            modelBuilder.Entity<Skills>().HasData(new Skills
            {
                Id = 8,
                JobSkill = "Modeling",
            });
            modelBuilder.Entity<Skills>().HasData(new Skills
            {
                Id = 9,
                JobSkill = "Architecture",
            });
            modelBuilder.Entity<Skills>().HasData(new Skills
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
                Email="hammad@gmail.com",
                ExperienceTime=5,
                ExpectedSalary = 300,
                Age =23,
                Qualification = Qualification.Bachelor
            });
            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 2,
                Name = "Ahtesham",
                ProfileImg = "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0",
                AboutMe = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;",
                Experience = "Php Laravel",
                Phone = 03000000,
                Location = Location.Lahore,
                Email = "Ahtesham@gmail.com",
                ExperienceTime = 6,
                ExpectedSalary = 400,
                Age = 23,
                Qualification = Qualification.Bachelor
            });
            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 3,
                Name = "Sohaib",
                ProfileImg = "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0",
                AboutMe = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;",
                Experience = "React Designer",
                Phone = 03000000,
                Location = Location.Islamabad,
                Email = "Sohaib@gmail.com",
                ExperienceTime = 8,
                ExpectedSalary = 500,
                Age = 23,
                Qualification = Qualification.Master
            });

            /*JobSkils data*/


            modelBuilder.Entity<JobSkills>().HasData(new JobSkills
            {
                Id = 1,
                JobId = 1,
                SkillId = 1,
            });
            modelBuilder.Entity<JobSkills>().HasData(new JobSkills
            {
                Id = 2,
                JobId = 1,
                SkillId = 2,
            });
            modelBuilder.Entity<JobSkills>().HasData(new JobSkills
            {
                Id = 3,
                JobId = 1,
                SkillId = 3,
            });

            modelBuilder.Entity<JobSkills>().HasData(new JobSkills
            {
                Id = 4,
                JobId = 2,
                SkillId = 3,
            });
            modelBuilder.Entity<JobSkills>().HasData(new JobSkills
            {
                Id = 5,
                JobId = 2,
                SkillId = 6,
            });
            modelBuilder.Entity<JobSkills>().HasData(new JobSkills
            {
                Id = 6,
                JobId = 3,
                SkillId = 6,
            });

            modelBuilder.Entity<JobClass>().HasData(new JobClass
            {
                Id = 1,
               name = "Feature"
            });
            modelBuilder.Entity<JobClass>().HasData(new JobClass
            {
                Id = 2,
                name = "Urgent"
            });
            modelBuilder.Entity<JobClass>().HasData(new JobClass
            {
                Id = 3,
                name = "Private"
            });

            /* Job Classes Data*/

            modelBuilder.Entity<AllJobsClasses>().HasData(new AllJobsClasses
            {
                Id = 1,
                JobId = 1,
                JobClassId = 1,
            });
            modelBuilder.Entity<AllJobsClasses>().HasData(new AllJobsClasses
            {
                Id = 2,
                JobId = 1,
                JobClassId = 2,
            });
            modelBuilder.Entity<AllJobsClasses>().HasData(new AllJobsClasses
            {
                Id = 3,
                JobId = 1,
                JobClassId = 3,
            });
            modelBuilder.Entity<AllJobsClasses>().HasData(new AllJobsClasses
            {
                Id = 4,
                JobId = 2,
                JobClassId = 1,
            });
            modelBuilder.Entity<AllJobsClasses>().HasData(new AllJobsClasses
            {
                Id = 5,
                JobId = 2,
                JobClassId = 2,
            });
            modelBuilder.Entity<AllJobsClasses>().HasData(new AllJobsClasses
            {
                Id = 6,
                JobId = 3,
                JobClassId = 3,
            });


            /* Employeers Data*/

            modelBuilder.Entity<Employeer>().HasData(new Employeer
            {
                Id = 1,
                CompanyName = "Avitex Agency",
                CompanyAbout = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.",
                CompanyLogo = "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0",
                Founded = DateTime.Now,
                Headquarters = "Las Vegas, NV 89107, USA",
                Industry = "It",
                CompanyWebsite = "https://jobs.nokriwp.com/",
                CompanyEmail="Avitex@gmail.com",
                CompanySize=200
            }) ;
            modelBuilder.Entity<Employeer>().HasData(new Employeer
            {
                Id = 2,
                CompanyName = "Demo 1",
                CompanyAbout = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.",
                CompanyLogo = "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0",
                Founded = DateTime.Now,
                Headquarters = "Lahore",
                Industry = "It",
                CompanyWebsite = "https://jobs.nokriwp.com/",
                CompanyEmail = "demo1@gmail.com",
                CompanySize = 50
            });
            modelBuilder.Entity<Employeer>().HasData(new Employeer
            {
                Id = 3,
                CompanyName = "Honda",
                CompanyAbout = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.",
                CompanyLogo = "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0",
                Founded = DateTime.Now,
                Headquarters = "Islamabad",
                Industry = "Machenical",
                CompanyWebsite = "https://jobs.nokriwp.com/",
                CompanyEmail = "honda@gmail.com",
                CompanySize = 600
            });

        }
    }
}
