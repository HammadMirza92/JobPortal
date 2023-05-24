using CsvHelper;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Models.Dto;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Formats.Asn1;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IEmailRepository _emailRepository;
        public JobController(IJobRepository jobRepository , IEmailRepository emailRepository)
        {
            _jobRepository = jobRepository;
            _emailRepository = emailRepository;

        }

        // GET: api/Job
        [HttpGet]
        /*[ResponseCache(Duration = 120)]*/
        public async Task<ActionResult<Job>> Get()
        {
            var jobs = await _jobRepository.GetAll();
            if (!jobs.Any())
            {
                return BadRequest("No Job Found");
            }
            return Ok(jobs);
        }

        // GET: api/Job/getAll
        [HttpGet("getAll")]
        [ResponseCache(Duration = 120)]
        public async Task<ActionResult<Job>> GetAllJobs()
        {
            var jobs = await _jobRepository.GetAllJobs();
            if (!jobs.Any())
            {
                return BadRequest("No Job Found");
            }
            return Ok(jobs);
        }

        // GET: api/Job/getFeatureJobs
        [HttpGet("getFeatureJobs")]
        [ResponseCache(Duration = 120)]
        public async Task<ActionResult<Job>> GetFeatureJobs()
        {
            var featureJobs = await _jobRepository.GetFeatureJobs();
            if (!featureJobs.Any())
            {
                return BadRequest("No Feature Job Found");
            }
            return Ok(featureJobs);
        }


        // GET: api/Job/getAll/{id}   : id = candidateId
        [HttpGet("getAll/{id}")]
        public async Task<ActionResult<Job>> GetAll(Guid id)
        {
            var jobs = await _jobRepository.GetAllJobs(id);
            if (!jobs.Any())
            {
                return BadRequest("No Job Found For This Candidate");
            }
            return Ok(jobs);
        }


        // GET: api/Job/getFeatureJobs/{id}   : id = candidateId
        [HttpGet("getFeatureJobs/{id}")]
        public async Task<ActionResult<Job>> GetFeatureJobs(Guid id)
        {
            var featureJobs = await _jobRepository.GetFeatureJobs( id);
            if (!featureJobs.Any())
            {
                return BadRequest("No Feature Job Found For This Candidate");
            }
            return Ok(featureJobs);
        }


        // GET api/Job/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> Get(Guid id)
        {
            var jobById = await _jobRepository.GetById(id);
            if (jobById == null)
            {
                return BadRequest("No Job Found");
            }
            return Ok(jobById);
        }


        // GET api/Job/FetchJobApplied/{id}
        [HttpGet("FetchJobApplied/{id}")]
        public async Task<ActionResult<AppliedJobs>> FetchJobApplied(Guid id)
        {
            var appliedJobs = await _jobRepository.FetchJobApplied(id);
            if (!appliedJobs.Any())
            {
                return BadRequest("No AppliedJob Found");
            }
            return Ok(appliedJobs);
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


        // POST api/Job/sendEmail
        [HttpPost("sendEmail")]
        public IActionResult SendEMail(SendEmail email)
        {
            try
            {
                _emailRepository.SendEmail(email, null);
            }
            catch (Exception)
            {

                BadRequest("Email Not Sent");
            }
           
            return Ok();

        }

        [HttpPost("searchJobs")]
        public async Task<IActionResult> SearchJobs(SearchJobs search)
        {
            var filterJobs = await _jobRepository.FilterJobs(search);
            if (filterJobs == null)
            {
                return NotFound();
            }
            return Ok(filterJobs);
        }
    }
}
