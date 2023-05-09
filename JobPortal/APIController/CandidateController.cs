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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
  
        }
        // GET: api/Job
        [HttpGet]
        /*[ResponseCache(Duration = 120)]*/
        public async Task<ActionResult<Candidate>> Get()
        {

            var allCandidates = await _candidateRepository.GetAll();
            if (!allCandidates.Any())
            {
                return BadRequest();
            }
            return Ok(allCandidates);
        }

        // GET api/Job/5
        [HttpGet("{id}")]
        public async Task<Candidate> Get(int id)
        {
            var candidate = await _candidateRepository.GetById(id);
            return candidate;
        }

        // POST api/Job
        [HttpPost("create")]
       /* [ResponseCache]*/
        public async Task<Candidate> Create(Candidate candidate)
        {
            var newCandidate = await _candidateRepository.Add(candidate);

            return newCandidate;

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
