using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    
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

        // GET: api/AppliedJobs
        [HttpGet]
        public async Task<ActionResult<AppliedJobs>> GetAll()
        {
            var allAppliedJobs = await _appliedJobsRepository.GetAll();
            if (!allAppliedJobs.Any())
            {
                return BadRequest();
            }
            return Ok(allAppliedJobs);
        }


        // GET: api/AppliedJobs/GetJobsofCandidate/{id}
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


        // GET api/AppliedJobs/{id}
        [HttpGet("{id}")]
        public async Task<AppliedJobs> Get(Guid id)
        {
            var job = await _appliedJobsRepository.GetById(id);
            return job;
        }


        // POST api/AppliedJobs
        [HttpPost("create")]
        [Authorize(Roles = "candidate")]
        public async Task<AppliedJobs> Create(AppliedJobs appliedJob)
        {

            var newAppliedJob = await _appliedJobsRepository.Add(appliedJob);

            var job = await _jobRepository.GetById(appliedJob.JobsId);
            var employer = await _employerRepository.GetById(job.EmployerId);
            var candidate = await _candidateRepository.GetById(appliedJob.CandidateId);

            string htmlTemplate = System.IO.File.ReadAllText("C:\\Users\\Hammad\\source\\repos\\JobPortal\\JobPortal\\EmailTemplate\\AppliedJobTemplate.html");

            htmlTemplate = htmlTemplate.Replace("{employerName}", employer.CompanyName);
            htmlTemplate = htmlTemplate.Replace("{candidateName}", candidate.Name);
            htmlTemplate = htmlTemplate.Replace("{jobTitle}", job.Title);
            htmlTemplate = htmlTemplate.Replace("{candidateEmail}", candidate.Email);
            htmlTemplate = htmlTemplate.Replace("{candidatePhone}", candidate.Phone.ToString());
            htmlTemplate = htmlTemplate.Replace("{candidateId}", candidate.Id.ToString());

            SendEmail email = new SendEmail()
            {
                To = employer.CompanyEmail,
              //  To = "hammad.hassan@purelogics.com",
                Subject = "Candidate Applied To job",
                Body = htmlTemplate
            };

            await _emailRepository.SendEmail(email, null);

            return newAppliedJob;

        }



        // DELETE api/AppliedJobs/{id}
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
        
    }
}
