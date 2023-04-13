using JobPortal.Models;
using JobPortal.Services.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        // GET: api/Job
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var jobs = await _jobRepository.GetAll();
            if (!jobs.Any())
            {
                return BadRequest();
            }
            return Ok(jobs);
        }

        // GET api/<JobController>/5
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

        // PUT api/<JobController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
