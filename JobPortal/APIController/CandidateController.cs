using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    /* [Authorize(Roles = "employer")]*/
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IApplicationUserRepository _appUserRepository;
        public CandidateController(ICandidateRepository candidateRepository, IApplicationUserRepository applicationUserRepository)
        {
            _candidateRepository = candidateRepository;
            _appUserRepository = applicationUserRepository;
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
        public async Task<Candidate> Get(Guid id)
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
            var id = candidate.Id;

            var candidateUser = await _appUserRepository.GetById(candidate.UserId);

            var newUser = new ApplicationUser()
            {
                Id = candidateUser.Id,
                ConcurrencyStamp = candidateUser.ConcurrencyStamp,
                FirstName = candidateUser.FirstName,
                LastName = candidateUser.LastName,
                EmployerId = candidateUser.EmployerId,
                CandidateId = id,
                Email= candidateUser.Email,
                UserName = candidateUser.UserName,
                NormalizedUserName = candidateUser.Email,
                NormalizedEmail = candidateUser.NormalizedEmail,
                EmailConfirmed = candidateUser.EmailConfirmed,
                PasswordHash = candidateUser.PasswordHash,
                SecurityStamp = candidateUser.SecurityStamp,
                PhoneNumber = candidateUser.PhoneNumber,
                LockoutEnabled = candidateUser.LockoutEnabled,
                AccessFailedCount = candidateUser.AccessFailedCount,
            };

            await _appUserRepository.Update(newUser);


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
