using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Models.Dto;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;

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
        private readonly IEmailRepository _emailRepository;
        public JobController(IJobRepository jobRepository, IJobClassRepository jobClassRepository, IAllJobsClassesRepository alljJobsClassesRepository, IEmailRepository emailRepository)
        {
            _jobRepository = jobRepository;
            _jobClassRepository = jobClassRepository;
            _alljJobsClassesRepository = alljJobsClassesRepository;
            _emailRepository = emailRepository;

        }

        // GET: api/Job
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

        // GET: api/Job/getFeatureJobs
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

        // GET: api/Job/getAll/{id}
        [HttpGet("getAll/{id}")]
        /*[ResponseCache(Duration = 120)]*/
        public async Task<ActionResult<Job>> GetAll(Guid id)
        {
            var jobs = await _jobRepository.GetAllJobs(id);
            if (!jobs.Any())
            {
                return BadRequest();
            }
            return Ok(jobs);
        }

        // GET: api/Job/getFeatureJobs/{id}
        [HttpGet("getFeatureJobs/{id}")]
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

        // GET api/Job/FetchJobApplied/{id}
        [HttpGet("FetchJobApplied/{id}")]
        public async Task<IEnumerable<AppliedJobs>> FetchJobApplied(Guid id)
        {
            var job = await _jobRepository.FetchJobApplied(id);
            return job;
        }

        // POST api/Job/create
        [HttpPost("create")]
        [Authorize(Roles = "employer")]
        public async Task<IActionResult> Create( Job job)
        {
            var newJob = await _jobRepository.Add(job);

            return Ok(newJob);

        }

        // POST api/Job/uploadImage
        [HttpPost("uploadImage")]
        public IActionResult UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("No image uploaded.");

            // Generate a unique image file name
            var imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

            if (image != null && image.Length > 0)
            {
                var filePath = Path.Combine("D:\\JobPortal\\src\\assets\\Images\\jobIcons\\", imageFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                var img = imageFileName.ToJson();
                return Ok(img);
            }

            return BadRequest("No image file received.");
        }
  

        // DELETE api/Job/delete/{id}
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "employer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var job = await _jobRepository.GetById(id);
            if (job == null)
            {
                return NotFound();
            }
            job.IsDeleted = true;
           await _jobRepository.Delete();
            return Ok(job);
        }


        [HttpPost("sendEmail")]
        public IActionResult SendEMail(SendEmail email)
        {

            _emailRepository.SendEmail(email);


            return Ok();

        }
    }
}
