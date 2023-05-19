using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerRepository _employeerRepository;
        private readonly IApplicationUserRepository _appUserRepository;
        private readonly IJobRepository _jobRepository;


        public EmployerController(IEmployerRepository employeerRepository, IApplicationUserRepository appUserRepository, IJobRepository jobRepository)
        {
            _employeerRepository = employeerRepository;
            _appUserRepository = appUserRepository;
            _jobRepository = jobRepository;     
        }

        // GET: api/Job
        [HttpGet]
        /*[ResponseCache(Duration = 120)]*/
        public async Task<ActionResult<Employer>> Get()
        {
          
            var allEmployeers = await _employeerRepository.GetAll();
            if (!allEmployeers.Any())
            {
                return BadRequest();
            }
            return Ok(allEmployeers);
        }

        // GET api/Job/5
        [HttpGet("{id}")]
        public async Task<Employer> Get(Guid id)
        {
            var employeer = await _employeerRepository.GetById(id);
            return employeer;
        }

        // POST api/Job
        [HttpPost("create")]
        public async Task<Employer> Create([FromBody] Employer employeer)
        {
            var newEmployeer = await _employeerRepository.Add(employeer);
            var id = newEmployeer.Id;

            var employerUser = await _appUserRepository.GetById(employeer.UserId);

            var newUser = new ApplicationUser() { 
                Id= employerUser.Id,
                ConcurrencyStamp = employerUser.ConcurrencyStamp,
                FirstName= employerUser.FirstName,
                LastName= employerUser.LastName,
                EmployerId = id ,
                UserName = employerUser.UserName,
                NormalizedUserName = employerUser.NormalizedUserName,
                Email = employerUser.Email,
                NormalizedEmail = employerUser.NormalizedEmail,
                EmailConfirmed = employerUser.EmailConfirmed,
                PasswordHash = employerUser.PasswordHash,
                SecurityStamp = employerUser.SecurityStamp,
                PhoneNumber = employerUser.PhoneNumber,
                LockoutEnabled = employerUser.LockoutEnabled,
                AccessFailedCount = employerUser.AccessFailedCount,
            };

             await _appUserRepository.Update(newUser);
            return newEmployeer;

        }
        [HttpPost("uploadImage")]
        public IActionResult UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("No image uploaded.");

            // Generate a unique image file name
            var imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

            if (image != null && image.Length > 0)
            {
                var filePath = Path.Combine("D:\\JobPortal\\src\\assets\\Images\\companyLogo\\", imageFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                var img = imageFileName.ToJson();
                return Ok(img);
            }

            return BadRequest("No image file received.");
        }
        // PUT api/Job/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Job/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public async Task updateJob()
        {
            var employers = await _employeerRepository.GetAll();
            foreach (var employer in employers)
            {
                foreach (var job in employer.JobOffered)
                {
                    if(job.DeadLine <= DateTime.Now)
                    {
                        Job newJob = new Job()
                        {
                            Id = job.Id,
                            Icon = job.Icon,
                            Title = job.Title,
                            Description = job.Description,
                            Responsibility = job.Responsibility,
                            Location = job.Location,
                            Type = job.Type,
                            Qualifications = job.Qualifications,
                            SalaryType = job.SalaryType,
                            StartBudget = job.StartBudget,
                            EndBudget = job.EndBudget,
                            JobExperience = job.JobExperience,
                            JobShift = job.JobShift,
                            JobStatus = JobStatus.Close,
                            DeadLine = job.DeadLine,
                            JobPosted = job.JobPosted,
                            Vacancy = job.Vacancy,
                            EmployerId = job.EmployerId,
                            Employer = job.Employer,
                            JobSkills = job.JobSkills,
                            AllJobsClasses = job.AllJobsClasses,
                        };

                        await _jobRepository.Update(newJob);
                    }
                }
            }

            return ;
        }
        
        
        [HttpPost("searchEmployer")]
        public async Task<IActionResult> SearchEmployer(SearchEmployer search)
        {
            var filterEmployers = await _employeerRepository.FilterEmployer(search);
   
            return Ok(filterEmployers);
        }
    }
}
