using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Models.Dto;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Net.Http.Headers;

namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IJobClassRepository _jobClassRepository;
        private readonly IAllJobsClassesRepository _alljJobsClassesRepository;
        public JobController(IJobRepository jobRepository, IJobClassRepository jobClassRepository, IAllJobsClassesRepository alljJobsClassesRepository)
        {
            _jobRepository = jobRepository;
            _jobClassRepository = jobClassRepository;
            _alljJobsClassesRepository = alljJobsClassesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Job>> Get()
        {
            var jobs = await _jobRepository.GetAll();
            if (!jobs.Any())
            {
                return BadRequest();
            }
            return Ok(jobs);
        }

        [HttpGet("getFeatureJobs")]
        public async Task<ActionResult<Job>> GetFeatureJobs()
        {
            var featureJobs = await _jobRepository.GetFeatureJobs();
            if (!featureJobs.Any())
            {
                return BadRequest();
            }
            return Ok(featureJobs);
        }

        // GET: api/Job
        [HttpGet("getAll/{id}")]
/*        [ResponseCache(Duration = 120)]
*/      public async Task<ActionResult<Job>> GetAll(Guid id)
        {
            var jobs = await _jobRepository.GetAllJobs(id);
            if (!jobs.Any())
            {
                return BadRequest();
            }
            return Ok(jobs);
        }

        [HttpGet("getFeatureJobs/{id}")]
       /* [ResponseCache(Duration = 120)]*/
        public async Task<ActionResult<Job>> GetFeatureJobs(Guid id)
        {
            var featureJobs = await _jobRepository.GetFeatureJobs( id);
            if (!featureJobs.Any())
            {
                return BadRequest();
            }
            return Ok(featureJobs);
        }

        // GET api/Job/5
        [HttpGet("{id}")]
        public async Task<Job> Get(Guid id)
        {
            var job = await _jobRepository.GetById(id);
            return job;
        }
        [HttpGet("FetchJobApplied/{id}")]
        public async Task<IEnumerable<AppliedJobs>> FetchJobApplied(Guid id)
        {
            var job = await _jobRepository.FetchJobApplied(id);
            return job;
        }
        // POST api/Job
        [HttpPost("create")]
        public async Task<IActionResult> Create( Job job)
        {

            /*if (job.Icon == null || job.Icon.Length == 0)
                return BadRequest("No image uploaded.");

            // Generate a unique image file name
            var imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(job.Icon.FileName);

            // Save the image to a folder on the server
            var imagePath = Path.Combine("C:\\Users\\Hammad\\source\\repos\\JobPortal\\JobPortal\\wwwroot\\uploadedFiles\\", imageFileName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await job.Icon.CopyToAsync(stream);
            }

            // Create a new product entity
            var createJob = new Job
            {
                Icon = imageFileName,
                Title = job.Title,
                Description = job.Description,
                Responsibility = job.Responsibility,
                Location = job.Location,
                Type= job.Type,
                Qualifications= job.Qualifications,
                SalaryType = job.SalaryType,
                StartBudget= job.StartBudget,
                EndBudget= job.EndBudget,
                JobExperience = job.JobExperience,
                JobShift= job.JobShift,
                JobStatus= job.JobStatus,
                DeadLine= job.DeadLine,
                JobPosted= job.JobPosted,
                Vacancy= job.Vacancy,
                EmployerId= job.EmployerId,
                Employer= job.Employer,
            };*/
            var newJob = await _jobRepository.Add(job);

            // Save the product entity to the database using Entity Framework Core or your preferred ORM
            // dbContext.Products.Add(product);
            // await dbContext.SaveChangesAsync();

            return Ok(newJob);

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
                var filePath = Path.Combine("D:\\JobPortal\\src\\assets\\Images\\", imageFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                var img = imageFileName.ToJson();
                return Ok(img);
            }

            return BadRequest("No image file received.");
        }


        [HttpPost("image")]
        public async Task<ActionResult<Job>> ImageCreate(IFormFile job)
        {
            var file = job;
            var featureJobs = await _jobRepository.GetFeatureJobs();
            if (!featureJobs.Any())
            {
                return BadRequest();
            }
            return Ok(featureJobs);

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
        
    }
}
