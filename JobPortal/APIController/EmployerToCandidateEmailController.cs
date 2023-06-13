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

        // POST: api/EmployerToCandidateEmail/sendEmailToCandidate
        [HttpPost("sendEmailToCandidate")]
        public async Task<ActionResult> SendEmailToCandidate(EmployerToCandidateEmail employerToCandidateEmail)
        {
        
            var job = await _jobRepository.GetById(employerToCandidateEmail.JobAppliedId);
            var company = await _employerRepository.GetById(employerToCandidateEmail.CompanyId);
            var candidate = await _candidateRepository.GetById(employerToCandidateEmail.CandidateId);

            //Get html template
            string htmlTemplate = System.IO.File.ReadAllText("C:\\Users\\Hammad\\source\\repos\\JobPortal\\JobPortal\\EmailTemplate\\JobAppliedTemplate.html");

            // add data into html template
            htmlTemplate = htmlTemplate.Replace("{candidateName}", candidate.Name);
            htmlTemplate = htmlTemplate.Replace("{jobTitle}", job.Title);
            htmlTemplate = htmlTemplate.Replace("{companyId}", company.Id.ToString());
            htmlTemplate = htmlTemplate.Replace("{companyName}", company.CompanyName);
            


            SendEmail email = new SendEmail()
            {
                To = candidate.Email,
               // To = "hammad.hassan@purelogics.com",
                Subject = "Confirmation to Job",
                Body = htmlTemplate
            };

            try
            {
                await _emailRepository.SendEmail(email, null);
            }
            catch (Exception)
            {

                throw;
            }
            
            return Ok();
        }
        
    }
}
