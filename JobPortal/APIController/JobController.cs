using JobPortal.Models;
using JobPortal.Services.IRepository;
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
        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        // GET: api/Job
        [HttpGet]
        [ResponseCache(Duration = 120)]
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
        [ResponseCache(Duration = 120)]
        public async Task<ActionResult<Job>> GetFeatureJobs()
        {
            var featurejobs = await _jobRepository.GetFeatureJobs();
            if (!featurejobs.Any())
            {
                return BadRequest();
            }
            return Ok(featurejobs);
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
        [ResponseCache]
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
