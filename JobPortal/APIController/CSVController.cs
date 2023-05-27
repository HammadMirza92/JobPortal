using CsvHelper;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using NuGet.Protocol;
using System.Globalization;
using static IdentityServer4.Models.IdentityResources;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    /* [Authorize(Roles = "employer")]*/
    public class CSVController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICSVRepository _csvRepository;
        private readonly IAppliedJobsRepository _appliedJobsRepository;

        public CSVController(IEmailRepository emailRepository, IEmployerRepository employerRepository, ICandidateRepository candidateRepository, ICSVRepository csvRepository, IAppliedJobsRepository appliedJobsRepository)
        {
            _emailRepository = emailRepository;
            _employerRepository = employerRepository;
            _candidateRepository = candidateRepository;
            _csvRepository = csvRepository;
            _appliedJobsRepository = appliedJobsRepository;
        }

        // POST: api/CSV/jobOfferedCSV
        [HttpPost("jobOfferedCSV")]
        public async Task<ActionResult> JobOfferedCSV(List<Job> job)
        {
            var employerId = job.FirstOrDefault().EmployerId;
            var employer = await _employerRepository.GetById(employerId);

            var filePath = await _csvRepository.JobsCSV(job);

            //Get html template
            string htmlTemplate = System.IO.File.ReadAllText("C:\\Users\\Hammad\\source\\repos\\JobPortal\\JobPortal\\EmailTemplate\\JobOfferedCSVTemplate.html");

            // add data into html template
            htmlTemplate = htmlTemplate.Replace("{companyName}", employer.CompanyName);
                  

            SendEmail email = new SendEmail()
            {
                To = employer.CompanyEmail,
                Subject = "CSV of Jobs",
                Body = htmlTemplate
            };

            await _emailRepository.SendEmail(email, filePath);

            return Ok();
        }

        // GET: api/CSV/allCandidateCSV
        [HttpGet("allCandidateCSV")]
        public async Task<ActionResult> AllCandidateCSV()
        {
            var candidates = await _candidateRepository.GetAll();
            
            var filePath = await _csvRepository.CandidateCSV(candidates);       

            //Get html template
            string htmlTemplate = System.IO.File.ReadAllText("C:\\Users\\Hammad\\source\\repos\\JobPortal\\JobPortal\\EmailTemplate\\AllCandidatesCSVTemplate.html");

            SendEmail email = new SendEmail()
            {
                To = "hammad.hassan@purelogics.com",
                Subject = "All Candidates CSV",
                Body = htmlTemplate
            };

            await _emailRepository.SendEmail(email, filePath);

            return Ok();
        }

        // GET: api/CSV/allEmployerCSV
        [HttpGet("allEmployerCSV")]
        public async Task<ActionResult> AllEmployerCSV()
        {
            var allEmployer = await _employerRepository.GetAll();

            var filePath = await _csvRepository.EmployerCSV(allEmployer);

            //Get html template
            string htmlTemplate = System.IO.File.ReadAllText("C:\\Users\\Hammad\\source\\repos\\JobPortal\\JobPortal\\EmailTemplate\\AllEmployerCSVTemplate.html");

            SendEmail email = new SendEmail()
            {
                To = "hammad.hassan@purelogics.com",
                Subject = "All Employer CSV",
                Body = htmlTemplate
            };

            await _emailRepository.SendEmail(email, filePath);

            return Ok();
        }

        // GET: api/CSV/allAppliedJobsCSV
        [HttpGet("allAppliedJobsCSV")]
        public async Task<ActionResult> AllAppliedJobsCSV()
        {
            var allAppliedJobs = await _appliedJobsRepository.GetAll();

            var filePath = await _csvRepository.AppliedJobsCSV(allAppliedJobs);

            //Get html template
            string htmlTemplate = System.IO.File.ReadAllText("C:\\Users\\Hammad\\source\\repos\\JobPortal\\JobPortal\\EmailTemplate\\AllAppliedJobsCSVTemplate.html");

            SendEmail email = new SendEmail()
            {
                To = "hammad.hassan@purelogics.com",
                Subject = "All Applied Jobs CSV",
                Body = htmlTemplate
            };

            await _emailRepository.SendEmail(email, filePath);

            return Ok();
        }

    }
}
