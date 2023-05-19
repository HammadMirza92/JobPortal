using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerToCandidateEmailController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IEmailRepository _emailRepository;
        public EmployerToCandidateEmailController(IJobRepository jobRepository,IEmployerRepository employerRepository, ICandidateRepository candidateRepository, IEmailRepository emailRepository)
        {
            _jobRepository = jobRepository;
            _employerRepository = employerRepository;
            _candidateRepository = candidateRepository;
            _emailRepository = emailRepository;

        }
        // GET: api/Job
        [HttpPost("sendEmailToCandidate")]
        public async Task<ActionResult> SendEmailToCandidate(EmployerToCandidateEmail employerToCandidateEmail)
        {
        
            var job = await _jobRepository.GetById(employerToCandidateEmail.JobAppliedId);
            var company = await _employerRepository.GetById(employerToCandidateEmail.CompanyId);
            var candidate = await _candidateRepository.GetById(employerToCandidateEmail.CandidateId);
            var body = " <div style=\"background-color: white;padding: 20px; box-shadow: 1px 0px 20px rgba(0, 0, 0, 0.148);width: 50%;font-family:Arial, Helvetica, sans-serif;margin:0 auto \"</div>" +
                "  <h1>Thank You for Applying</h1>" +
                "  <strong>Dear " + candidate.Name + " ,</strong>" +
                "  <p>Thank you for applying to the " + job.Title + " job position at our company. " + "<strong>[ " + company.CompanyName + " ]</strong>" +
                "  We appreciate your interest and taking the time to submit your application.</p>" +
                "  <p>We have received your application and will review it carefully. If your qualifications match our requirements, we will reach out to you for the next steps in the hiring process.</p>" +
                "  <p>Once again, we appreciate your interest in our company and the opportunity to consider you for this position.</p>" +
                "  <p>Best regards,</p>" +
                "  <p>HR Team " + company.CompanyName + "</p>" +
                "  </div>";

            SendEmail email = new SendEmail()
            {
                To = candidate.Email,
                Subject = "Confirmation to Job",
                Body = body
            };
            await _emailRepository.SendEmail(email,null);
            return Ok();
        }
        
    }
}
