using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
/*    [Authorize]
*/    public class AppliedJobsController : ControllerBase
    {
        private readonly IAppliedJobsRepository _appliedJobsRepository;
        public AppliedJobsController(IAppliedJobsRepository appliedJobsRepository)
        {
            _appliedJobsRepository = appliedJobsRepository;
           
        }
        // GET: api/Job
        [HttpGet("GetJobsofCandidate/{id}")]
        public async Task<ActionResult<AppliedJobs>> GetJobsofCandidate(Guid id)
        {
            var JobsOfConadidate = await _appliedJobsRepository.GetJobByCandidateId(id);
            if (!JobsOfConadidate.Any())
            {
                return BadRequest();
            }
            return Ok(JobsOfConadidate);
        }
      

        // GET api/Job/5
        [HttpGet("{id}")]
        public async Task<AppliedJobs> Get(Guid id)
        {
            var job = await _appliedJobsRepository.GetById(id);
            return job;
        }

        // POST api/Job
        [HttpPost("create")]
        public async Task<AppliedJobs> Create(AppliedJobs appliedJob)
        {
            var newAppliedJob = await _appliedJobsRepository.Add(appliedJob);

            return newAppliedJob;

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
