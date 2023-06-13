using JobPortal.Enums;
using JobPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.AppDbContext
{
    public static class DataSeeding
    {
        public static async Task Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                DateTime currentDate = DateTime.Now;
                DateTime nextDate = currentDate.AddDays(5);

                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                context.Database.Migrate(); // apply all migrations

                var _userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                var _roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                if (!context.Users.Any(usr => usr.UserName == "adminhammad@gmail.com"))
                {
                    var user = new ApplicationUser()
                    {
                        Id = "d711015e-ec50-4857-9d6b-f07a459debe2",
                        UserName = "adminhammad@gmail.com",
                        Email = "adminhammad@gmail.com",
                    };

                    var userResult = _userManager.CreateAsync(user, "admin").Result;

                    var role = _userManager.AddToRoleAsync(user, "admin").Result;

                }

                if (!context.Users.Any(usr => usr.UserName == "employer1@gmail.com"))
                {
                    var user = new ApplicationUser()
                    {
                        Id = "2fe7daaa-bb2f-43a6-915b-083816e43b87",
                        UserName = "employer1@gmail.com",
                        Email = "employer1@gmail.com",
                    };

                    var userResult = _userManager.CreateAsync(user, "pppp").Result;

                    var role = _userManager.AddToRoleAsync(user, "employer").Result;
                    var employer = new Employer()
                    {
                        Id = Guid.Parse("262ff2ba-d323-4916-b767-e9f1707ef7a2"),
                        CompanyName = "Digital Flies",
                        CompanyEmail = "digitalflies@gmail.com",
                        CompanyAbout = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.",
                        CompanyLogo = "f2bfaf5c-b8aa-47c5-915c-f9719ec5a1a7.jpg",
                        Founded = DateTime.UtcNow,
                        Headquarters = "Las Vegas, NV 89107, USA",
                        Industry = "It",
                        CompanyWebsite = "https://jobs.nokriwp.com/",
                        CompanySize = 200,
                        UserId = user.Id
                    };

                    var addEmployer = context.Employer.Add(employer).Entity;
                    user.EmployerId = addEmployer.Id;

                    var job =  new Job
                    {
                        Id = Guid.Parse("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"),
                        Icon = "6300ce91-db26-4348-bb9a-ca606fe43caa-Job1.jpg",
                        Title = "Marketing Manager",
                        Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
                        Responsibility = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
                        Location = Location.Lahore,
                        Type = JobType.FullTime,
                        Qualifications = Qualification.Bachelor,
                        SalaryType = SalaryType.Monthly,
                        JobExperience = JobExperience.Oneyear,
                        StartBudget = 20000,
                        EndBudget = 40000,
                        JobShift = JobShift.Morning,
                        JobStatus = JobStatus.Open,
                        Vacancy = 20,
                        DeadLine = nextDate,
                        EmployerId = addEmployer.Id,
                    };
                    var addJob = context.Jobs.Add(job).Entity;
                    /*context.SaveChanges();*/

                    var firstJobSkill = new JobSkills
                    {
                        Id = Guid.Parse("037bb42e-67a5-4105-bb3c-539bb8d8a906"),
                        JobId = Guid.Parse("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"),
                        SkillId = Guid.Parse("aafbde46-32ee-45bd-b52a-a76a1ac12a78"),
                    };
                    var firstJobSkilladded = context.JobSkills.Add(firstJobSkill).Entity;
                   /* context.SaveChanges();*/

                    var secondJobSkill = new JobSkills
                    {
                        Id = Guid.Parse("fad6993c-c654-4c17-9078-174818d7236f"),
                        JobId = Guid.Parse("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"),
                        SkillId = Guid.Parse("bae33518-8dc8-4d53-80ca-e8f58a9fd808"),
                    };
                    var secondJobSkilladded = context.JobSkills.Add(secondJobSkill).Entity;
                   /* context.SaveChanges();*/

                    var thirdJobSkill = new JobSkills
                    {
                        Id = Guid.Parse("272eaf21-8b37-4562-b440-96b4befe752f"),
                        JobId = Guid.Parse("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"),
                        SkillId = Guid.Parse("0b886a97-0b5a-44e0-b1a9-c1ddecb67f2d"),
                    };
                    var thirdJobSkilladded = context.JobSkills.Add(thirdJobSkill).Entity;
                   /* context.SaveChanges();*/

                    var firstJobClass = new AllJobsClasses
                    {
                        Id = Guid.Parse("e2865ba0-ee6c-43d8-a61e-4b9df0f1d386"),
                        JobId = Guid.Parse("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"),
                        JobClassId = Guid.Parse("642a9e91-5c4a-4284-aa0f-69e39a93ea6d"),
                    };
                    var firstJobClassadded = context.AllJobsClasses.Add(firstJobClass).Entity;
                   /* context.SaveChanges();*/

                    var secondJobClass = new AllJobsClasses
                    {
                        Id = Guid.Parse("0d84a83a-3460-41e1-a942-49dd6d0411bd"),
                        JobId = Guid.Parse("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"),
                        JobClassId = Guid.Parse("63acd142-d323-42c5-a453-1b67f40fd073"),
                    };
                    var secondJobClassadded = context.AllJobsClasses.Add(secondJobClass).Entity;
                  /*  context.SaveChanges();*/

                    var thirdJobClass = new AllJobsClasses
                    {
                        Id = Guid.Parse("02d42141-3627-48e2-a9ee-4142f85ca4e5"),
                        JobId = Guid.Parse("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"),
                        JobClassId = Guid.Parse("930c379d-d9e6-4a48-82b0-4f586d6aafc8"),
                    };
                    var thirdJobClassadded = context.AllJobsClasses.Add(thirdJobClass).Entity;
                    context.SaveChanges();

                }

                if (!context.Users.Any(usr => usr.UserName == "employer2@gmail.com"))
                {
                    var user = new ApplicationUser()
                    {
                        Id = "088fffd7-94b4-448e-9b67-5619fcf19441",
                        UserName = "employer2@gmail.com",
                        Email = "employer2@gmail.com",
                    };

                    var userResult = _userManager.CreateAsync(user, "pppp").Result;

                    var role = _userManager.AddToRoleAsync(user, "employer").Result;
                    var employer = new Employer()
                    {
                        Id = Guid.Parse("680b65c6-46cf-48ac-88f7-29ab807b29d5"),
                        CompanyName = "Seasons",
                        CompanyEmail = "seasons@gmail.com",
                        CompanyAbout = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.",
                        CompanyLogo = "79d9cea3-0e9a-4555-b971-58e672f76341.jpg",
                        Founded = DateTime.UtcNow,
                        Headquarters = "Lahore",
                        Industry = "It",
                        CompanyWebsite = "https://jobs.nokriwp.com/",
                        CompanySize = 50,
                        UserId = user.Id
                    };

                    var addEmployer = context.Employer.Add(employer).Entity;
                    user.EmployerId = addEmployer.Id;

                    var job = new Job
                    {
                        Id = Guid.Parse("eec67987-eb6a-4251-95aa-ede40e76332f"),
                        Icon = "7c8f5675-8ace-4998-bcfb-7058a5cd2a18-Job2.jpg",
                        Title = "Software Engineer",
                        Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
                        Responsibility = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
                        Location = Location.Karachi,
                        Type = JobType.FullTime,
                        Qualifications = Qualification.Bachelor,
                        SalaryType = SalaryType.Monthly,
                        JobExperience = JobExperience.AboveFive,
                        StartBudget = 30000,
                        EndBudget = 70000,
                        JobShift = JobShift.Morning,
                        JobStatus = JobStatus.Open,
                        Vacancy = 5,
                        DeadLine = nextDate,
                        EmployerId = addEmployer.Id,
                    };
                    var addJob = context.Jobs.Add(job).Entity;
                   /* context.SaveChanges();*/

                    var firstJobSkill = new JobSkills
                    {
                        Id = Guid.Parse("ca58283f-d5f4-4eb0-92e3-6873e6821129"),
                        JobId = Guid.Parse("eec67987-eb6a-4251-95aa-ede40e76332f"),
                        SkillId = Guid.Parse("0b886a97-0b5a-44e0-b1a9-c1ddecb67f2d"),
                    };
                    var firstJobSkilladded = context.JobSkills.Add(firstJobSkill).Entity;
                 /*   context.SaveChanges();*/

                    var secondJobSkill = new JobSkills
                    {
                        Id = Guid.Parse("340a0320-8302-4860-999f-3a256a785a20"),
                        JobId = Guid.Parse("eec67987-eb6a-4251-95aa-ede40e76332f"),
                        SkillId = Guid.Parse("010039fb-a687-4db5-8ada-3b586d3a4788"),
                    };
                    var secondJobSkilladded = context.JobSkills.Add(secondJobSkill).Entity;
                  /*  context.SaveChanges();*/

                    var firstJobClass = new AllJobsClasses
                    {
                        Id = Guid.Parse("63c2a7a6-8ebb-4bc9-ac98-8465abbb9994"),
                        JobId = Guid.Parse("eec67987-eb6a-4251-95aa-ede40e76332f"),
                        JobClassId = Guid.Parse("642a9e91-5c4a-4284-aa0f-69e39a93ea6d"),
                    };
                    var firstJobClassadded = context.AllJobsClasses.Add(firstJobClass).Entity;
                   /* context.SaveChanges();*/

                    var secondJobClass = new AllJobsClasses
                    {
                        Id = Guid.Parse("a4b97db1-2aff-49a7-be60-c59867fd74d7"),
                        JobId = Guid.Parse("eec67987-eb6a-4251-95aa-ede40e76332f"),
                        JobClassId = Guid.Parse("63acd142-d323-42c5-a453-1b67f40fd073"),
                    };
                    var secondJobClassadded = context.AllJobsClasses.Add(secondJobClass).Entity;
                    context.SaveChanges();
                }

                if (!context.Users.Any(usr => usr.UserName == "employer3@gmail.com"))
                {
                    var user = new ApplicationUser()
                    {
                        Id = "06e4bc68-0d75-429c-b513-e12c2ab03494",
                        UserName = "employer3@gmail.com",
                        Email = "employer3@gmail.com",
                    };

                    var userResult = _userManager.CreateAsync(user, "pppp").Result;

                    var role = _userManager.AddToRoleAsync(user, "employer").Result;
                    var employer = new Employer()
                    {
                        Id = Guid.Parse("4ea1f880-57ef-4f0b-8a19-5aa356e93091"),
                        CompanyName = "Lorem Ipsum",
                        CompanyEmail = "loremipusm@gmail.com",
                        CompanyAbout = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.",
                        CompanyLogo = "3e931480-2756-49e3-a8f0-66f8a7a05037.jpg",
                        Founded = DateTime.UtcNow,
                        Headquarters = "Islamabad",
                        Industry = "Machenical",
                        CompanyWebsite = "https://jobs.nokriwp.com/",
                        CompanySize = 600,
                        UserId = user.Id
                    };

                    var addEmployer = context.Employer.Add(employer).Entity;
                    user.EmployerId = addEmployer.Id;

                    var job = new Job
                    {
                        Id = Guid.Parse("4db3c416-6eae-4f01-bfd3-1ff3b45aea98"),
                        Icon = "1c38ec5e-04a1-42d9-bee5-a09864ec20d5-Job3.png",
                        Title = "Product Designer",
                        Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
                        Responsibility = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
                        Location = Location.Lahore,
                        Type = JobType.PartTime,
                        Qualifications = Qualification.Master,
                        SalaryType = SalaryType.Monthly,
                        JobExperience = JobExperience.Threeyears,
                        StartBudget = 15000,
                        EndBudget = 35000,
                        JobShift = JobShift.Night,
                        JobStatus = JobStatus.Open,
                        Vacancy = 50,
                        DeadLine = nextDate,
                        EmployerId = addEmployer.Id
                    };
                    var addJob = context.Jobs.Add(job).Entity;
                   /* context.SaveChanges();*/

                    var secondJob = new Job
                    {
                        Id = Guid.Parse("1a667533-5826-42f5-add4-15e8d930db45"),
                        Icon = "81d7952a-fbd1-470d-bbbf-3f39c9ee0b60.jpg",
                        Title = "MERN",
                        Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
                        Responsibility = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
                        Location = Location.Multan,
                        Type = JobType.Contract,
                        Qualifications = Qualification.Bachelor,
                        SalaryType = SalaryType.Hourly,
                        JobExperience = JobExperience.Fouryears,
                        StartBudget = 25000,
                        EndBudget = 40000,
                        JobShift = JobShift.Night,
                        JobStatus = JobStatus.Open,
                        Vacancy = 50,
                        DeadLine = nextDate,
                        EmployerId = addEmployer.Id
                    };
                    var addSecondJob = context.Jobs.Add(secondJob).Entity;
                   /* context.SaveChanges();*/

                    var firstJobSkill = new JobSkills
                    {
                        Id = Guid.Parse("f0f7f73e-aad5-416a-af2f-0153f313ae05"),
                        JobId = Guid.Parse("4db3c416-6eae-4f01-bfd3-1ff3b45aea98"),
                        SkillId = Guid.Parse("010039fb-a687-4db5-8ada-3b586d3a4788"),
                    };
                    var firstJobSkilladded = context.JobSkills.Add(firstJobSkill).Entity;
                    /*context.SaveChanges();*/

                    var firstJobClass = new AllJobsClasses
                    {
                        Id = Guid.Parse("6c931ccd-e4db-4671-a7b9-b5be4b1b69ca"),
                        JobId = Guid.Parse("4db3c416-6eae-4f01-bfd3-1ff3b45aea98"),
                        JobClassId = Guid.Parse("930c379d-d9e6-4a48-82b0-4f586d6aafc8"),
                    };
                    var firstJobClassadded = context.AllJobsClasses.Add(firstJobClass).Entity;
                    context.SaveChanges();

                }

                if (!context.Users.Any(usr => usr.UserName == "candidate1@gmail.com"))
                {
                    var user = new ApplicationUser()
                    {
                        Id = "995ce588-b342-47b8-88f7-349365f898f9",
                        UserName = "candidate1@gmail.com",
                        Email = "candidate1@gmail.com",
                    };

                    var userResult = _userManager.CreateAsync(user, "pppp").Result;

                    var role = _userManager.AddToRoleAsync(user, "candidate").Result;
                    var candidate = new Candidate()
                    {
                        Id = Guid.Parse("1163535c-d87f-4a75-8e85-e0d69eb9f0ea"),
                        Name = "Hammad Mirza",
                        Email = "hammadcandidate@gmail.com",
                        ProfileImg = "edc73289-42ac-4c32-927a-b252fb2b1da9.jpg",
                        AboutMe = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;",
                        Experience = ".Net Developer",
                        Phone = 03000000,
                        Location = Location.Lahore,
                        ExperienceTime = 5,
                        ExpectedSalary = 300,
                        Age = 23,
                        Qualification = Qualification.Bachelor,
                        UserId = user.Id
                    };

                    var addCandidate = context.Candidate.Add(candidate).Entity;
                    user.CandidateId = addCandidate.Id;


                    var firstCandidateSkill = new CandidateSkills
                    {
                        Id = Guid.Parse("66b6ad12-bce1-4928-a59d-de02192a7c10"),
                        CandidateId = Guid.Parse("1163535c-d87f-4a75-8e85-e0d69eb9f0ea"),
                        SkillId = Guid.Parse("9a126650-2936-442e-92ba-7d7dc32ff6f9"),
                    };
                    var firstCandidateSkilladded = context.CandidateSkills.Add(firstCandidateSkill).Entity;
                   /* context.SaveChanges();*/

                    var secondCandidateSkill = new CandidateSkills
                    {
                        Id = Guid.Parse("4cf506e5-818e-4f35-ac3c-000f3e87a604"),
                        CandidateId = Guid.Parse("1163535c-d87f-4a75-8e85-e0d69eb9f0ea"),
                        SkillId = Guid.Parse("010039fb-a687-4db5-8ada-3b586d3a4788"),
                    };
                    var secondCandidateSkilladded = context.CandidateSkills.Add(secondCandidateSkill).Entity;
                  /*  context.SaveChanges();*/

                    var thirdCandidateSkill = new CandidateSkills
                    {
                        Id = Guid.Parse("af2e3fb6-a3b7-4e1a-83e4-5ee05dde72d7"),
                        CandidateId = Guid.Parse("1163535c-d87f-4a75-8e85-e0d69eb9f0ea"),
                        SkillId = Guid.Parse("b749f4b8-3bc3-4a05-816b-56e0d12dfaaa"),
                    };
                    var thirdCandidateSkilladded = context.CandidateSkills.Add(thirdCandidateSkill).Entity;
                   /* context.SaveChanges();*/


                    var firstJobApplied = new AppliedJobs
                    {
                        Id = Guid.Parse("71d20425-06eb-4aa3-9da7-7deab8952f26"),
                        JobsId = Guid.Parse("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"),
                        CandidateId = Guid.Parse("1163535c-d87f-4a75-8e85-e0d69eb9f0ea"),
                    };
                    var firstJobAppliedadded = context.AppliedJobs.Add(firstJobApplied).Entity;
                   /* context.SaveChanges();*/

                    var seconJobApplied = new AppliedJobs
                    {
                        Id = Guid.Parse("3d493df5-0f7b-4a3d-a4e3-90f7d652e4a0"),
                        JobsId = Guid.Parse("eec67987-eb6a-4251-95aa-ede40e76332f"),
                        CandidateId = Guid.Parse("1163535c-d87f-4a75-8e85-e0d69eb9f0ea"),
                    };
                    var seconJobAppliedadded = context.AppliedJobs.Add(seconJobApplied).Entity;
                    context.SaveChanges();
                }

                if (!context.Users.Any(usr => usr.UserName == "candidate2@gmail.com"))
                {
                    var user = new ApplicationUser()
                    {
                        Id = "cc53dc1c-a0d0-49a3-8f31-06b320fe22a9",
                        UserName = "candidate2@gmail.com",
                        Email = "candidate2@gmail.com",
                    };

                    var userResult = _userManager.CreateAsync(user, "pppp").Result;

                    var role = _userManager.AddToRoleAsync(user, "candidate").Result;
                    var candidate = new Candidate()
                    {
                        Id = Guid.Parse("31bb5001-4266-4b90-992e-2a729b26d26b"),
                        Name = "Ahtesham",
                        Email = "ahteshamcandidate@gmail.com",
                        ProfileImg = "edc73289-42ac-4c32-927a-b252fb2b1da9.jpg",
                        AboutMe = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;",
                        Experience = "Php Laravel",
                        Phone = 03000000,
                        Location = Location.Lahore,
                        ExperienceTime = 6,
                        ExpectedSalary = 400,
                        Age = 23,
                        Qualification = Qualification.Bachelor,
                        UserId = user.Id,
                    };

                    var addCandidate = context.Candidate.Add(candidate).Entity;
                    user.CandidateId = addCandidate.Id;


                    var firstCandidateSkill = new CandidateSkills
                    {
                        Id = Guid.Parse("232c30ea-e8f6-446a-9af1-a2a20cc1c422"),
                        CandidateId = Guid.Parse("31bb5001-4266-4b90-992e-2a729b26d26b"),
                        SkillId = Guid.Parse("aafbde46-32ee-45bd-b52a-a76a1ac12a78"),
                    };
                    var firstCandidateSkilladded = context.CandidateSkills.Add(firstCandidateSkill).Entity;
                   /* context.SaveChanges();*/

                    var firstJobApplied = new AppliedJobs
                    {
                        Id = Guid.Parse("295aa12b-2238-478e-a8a2-d4e31c26800d"),
                        JobsId = Guid.Parse("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"),
                        CandidateId = Guid.Parse("31bb5001-4266-4b90-992e-2a729b26d26b"),
                    };
                    var firstJobApplieddadded = context.AppliedJobs.Add(firstJobApplied).Entity;
                    context.SaveChanges();

                }

                if (!context.Users.Any(usr => usr.UserName == "candidate3@gmail.com"))
                {
                    var user = new ApplicationUser()
                    {
                        Id = "4e9e311a-0926-423c-b136-eab5ba39998a",
                        UserName = "candidate3@gmail.com",
                        Email = "candidate3@gmail.com",
                    };

                    var userResult = _userManager.CreateAsync(user, "pppp").Result;

                    var role = _userManager.AddToRoleAsync(user, "candidate").Result;
                    var candidate = new Candidate()
                    {
                        Id = Guid.Parse("6209c878-b598-4939-bccf-909e58d12504"),
                        Name = "Sohaib",
                        Email = "sohaibCandidate@gmail.com",
                        ProfileImg = "edc73289-42ac-4c32-927a-b252fb2b1da9.jpg",
                        AboutMe = "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;",
                        Experience = "React Designer",
                        Phone = 03000000,
                        Location = Location.Islamabad,
                        ExperienceTime = 8,
                        ExpectedSalary = 500,
                        Age = 23,
                        Qualification = Qualification.Master,
                        UserId = user.Id,
                    };

                    var addCandidate = context.Candidate.Add(candidate).Entity;
                    user.CandidateId = addCandidate.Id;


                    var firstCandidateSkill = new CandidateSkills
                    {
                        Id = Guid.Parse("26ae6b7d-0ac2-461a-9a11-42f965a2d977"),
                        CandidateId = Guid.Parse("6209c878-b598-4939-bccf-909e58d12504"),
                        SkillId = Guid.Parse("0b886a97-0b5a-44e0-b1a9-c1ddecb67f2d"),
                    };
                    var firstCandidateSkilladded = context.CandidateSkills.Add(firstCandidateSkill).Entity;
                   /* context.SaveChanges();*/

                    var secondCandidateSkill = new CandidateSkills
                    {
                        Id = Guid.Parse("2aa2ed81-38c6-47a3-bfd0-90c031f340df"),
                        CandidateId = Guid.Parse("6209c878-b598-4939-bccf-909e58d12504"),
                        SkillId = Guid.Parse("83c89321-daf9-4ade-b229-d57615a32f10"),
                    };
                    var secondCandidateSkilladded = context.CandidateSkills.Add(secondCandidateSkill).Entity;
                  /*  context.SaveChanges();*/

                    var thirdCandidateSkill = new CandidateSkills
                    {
                        Id = Guid.Parse("037bb42e-67a5-4105-bb3c-539bb8d8a906"),
                        CandidateId = Guid.Parse("6209c878-b598-4939-bccf-909e58d12504"),
                        SkillId = Guid.Parse("2dd27837-b570-4c81-8bfc-bf8cad8323b6"),
                    };
                    var thirdCandidateSkilladded = context.CandidateSkills.Add(thirdCandidateSkill).Entity;
                    context.SaveChanges();

                }
            }
        }
    }
}
