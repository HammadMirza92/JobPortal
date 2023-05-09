using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerRepository _employeerRepository;
        private readonly IApplicationUserRepository _appUserRepository;

        public EmployerController(IEmployerRepository employeerRepository, IApplicationUserRepository appUserRepository)
        {
            _employeerRepository = employeerRepository;
            _appUserRepository = appUserRepository;
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
        public async Task<Employer> Get(int id)
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
                EmployeerId = id ,
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
