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

namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    /* [Authorize(Roles = "employer")]*/
    public class CSVController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IEmployerRepository _employerRepository;

        public CSVController(IEmailRepository emailRepository, IEmployerRepository employerRepository)
        {
            _emailRepository = emailRepository;
            _employerRepository = employerRepository;

        }
        // GET: api/CSV/jobOfferedCSV
        [HttpPost("jobOfferedCSV")]
        public async Task<ActionResult> JobOfferedCSV(List<Job> job)
        {
            var employerId = job.FirstOrDefault().EmployerId;
            var employer = await _employerRepository.GetById(employerId);
            using StringWriter stringWriter = new StringWriter();
            using CsvWriter csvWriter = new CsvWriter(stringWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteField("Job Title");
            csvWriter.WriteField("Job Description");
            csvWriter.WriteField("Job Responsibility");
            csvWriter.WriteField("Job Location");
            csvWriter.WriteField("Job Type");
            csvWriter.WriteField("Job Qualification");
            csvWriter.WriteField("Job SalarayType");
            csvWriter.WriteField("Job Start Budget");
            csvWriter.WriteField("Job End Budget");
            csvWriter.WriteField("Job Experience");
            csvWriter.WriteField("Job Shift");
            csvWriter.WriteField("Job Status");
            csvWriter.WriteField("Job DeadLine");
            csvWriter.WriteField("Job Posted Date");
            csvWriter.WriteField("Job Vacancy");
            csvWriter.WriteField("Job End Budget");
            csvWriter.NextRecord();

            foreach (var item in job)
            {
                csvWriter.WriteField(item.Title);
                csvWriter.WriteField(item.Description);
                csvWriter.WriteField(item.Responsibility);
                csvWriter.WriteField(item.Location);
                csvWriter.WriteField(item.Type);
                csvWriter.WriteField(item.Qualifications);
                csvWriter.WriteField(item.Type);
                csvWriter.WriteField(item.StartBudget);
                csvWriter.WriteField(item.EndBudget);
                csvWriter.WriteField(item.JobExperience);
                csvWriter.WriteField(item.JobShift);
                csvWriter.WriteField(item.JobStatus);
                csvWriter.WriteField(item.DeadLine);
                csvWriter.WriteField(item.JobPosted);
                csvWriter.WriteField(item.Vacancy);
                csvWriter.WriteField(item.EndBudget);
    

                csvWriter.NextRecord(); // Move to the next line
            }
            string csvData = stringWriter.ToString();
            Guid csvId = Guid.NewGuid();
            string filePath = "D:\\JobPortal\\src\\assets\\Images\\CSV\\" + csvId+ ".csv";

            System.IO.File.WriteAllText(filePath, csvData);

            var body = "<h1>CSV File</h1> here is the csv file ";
            SendEmail email = new SendEmail()
            {
                 To = employer.CompanyEmail,
                //To = "hammad.hassan@purelogics.com",
                Subject = "CSV",
                Body = body
            };

            await _emailRepository.SendEmail(email, filePath);

            return Ok();
        }

       
    }
}
