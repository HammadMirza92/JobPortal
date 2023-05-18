using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "candidate")]
    public class AppliedJobsController : ControllerBase
    {
        private readonly IAppliedJobsRepository _appliedJobsRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IEmailRepository _emailRepository;
        public AppliedJobsController(IAppliedJobsRepository appliedJobsRepository,IEmailRepository emailRepository, IEmployerRepository employerRepository,IJobRepository jobRepository,ICandidateRepository candidateRepository)
        {
            _appliedJobsRepository = appliedJobsRepository;
            _emailRepository = emailRepository;
            _employerRepository = employerRepository;
            _jobRepository = jobRepository;
            _candidateRepository = candidateRepository;
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

            var job = await _jobRepository.GetById(appliedJob.JobsId);
            var employer = await _employerRepository.GetById(job.EmployerId);
            var candidate = await _candidateRepository.GetById(appliedJob.CandidateId);
           
            var body = "<div style=\"background-color: white;padding: 20px; box-shadow: 1px 0px 20px rgba(0, 0, 0, 0.148);border:1px solid gray;width: 50%;font-family:Arial, Helvetica, sans-serif;margin:0 auto \">" +
            "  <h1>Congratulations!</h1>" +
               " <strong>Dear " + employer.CompanyName + ",</strong>" +
               " <p>We are pleased to inform you that a candidate " + candidate.Name + " has applied for the " + job.Title + " job position at your company. " +
               "Congratulations on receiving this application!</p> <p>The candidate's details are as follows:</p>" +
               " <ul> " +
               "    <li>Name: " + candidate.Name + " </li>" +
               "    <li>Email: " + candidate.Email + "</li>" +
               "    <li>Phone: " + candidate.Phone + "</li>" +
               "  </ul>" +
               "  <p>Please review the candidate's application and consider them for the position. If you have any further questions or require additional information, you can reach out to the candidate directly using the provided contact details.</p>" +
               "  <p>Thank you for your time and consideration. We wish you the best in finding the right candidate for your job opening.</p>" +
               "  <p>Best regards,</p>" +
               "  <p>GetToJob</p>" +
               "</div>";
            SendEmail email = new SendEmail()
            {
                To = employer.CompanyEmail,
                Subject = "Candidate Applied To job",
                Body = body
            };

            await _emailRepository.SendEmail(email);

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
