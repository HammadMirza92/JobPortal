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
    public class EmployeerController : ControllerBase
    {
        private readonly IEmployerRepository _employeerRepository;

        public EmployeerController(IEmployerRepository employeerRepository)
        {
            _employeerRepository = employeerRepository;
  
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
        [ResponseCache]
        public async Task<Employer> Create(Employer employeer)
        {
            var newEmployeer = await _employeerRepository.Add(employeer);

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
