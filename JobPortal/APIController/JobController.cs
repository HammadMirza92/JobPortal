using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
        // GET: api/Job
        [HttpGet]
        [ResponseCache(Duration = 120)]
        public async Task<ActionResult<Job>> Get()
        {
           // await _alljJobsClassesRepository.GetAllJobs();


            var jobs = await _jobRepository.GetAll();
            if (!jobs.Any())
            {
                return BadRequest();
            }
            return Ok(jobs);
        }
        [HttpGet("getFeatureJobs")]
        [ResponseCache(Duration = 120)]
        public async Task<ActionResult<Job>> GetFeatureJobs()
        {
            var featureJobs = await _jobRepository.GetFeatureJobs();
            if (!featureJobs.Any())
            {
                return BadRequest();
            }
            return Ok(featureJobs);
        }

        // GET api/Job/5
        [HttpGet("{id}")]
        public async Task<Job> Get(int id)
        {
            var job = await _jobRepository.GetById(id);
            return job;
        }

        // POST api/Job
        [HttpPost("create")]
        public async Task<Job> Create(Job job)
        {
            var newJob = await _jobRepository.Add(job);

            return newJob;

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
