using JobPortal.Models;
using JobPortal.Services.IRepository;
using CsvHelper;
using System.Globalization;
using System.IO;

namespace JobPortal.Services.Repository
{
    public class CSVRepository: ICSVRepository
    {
      

        // Make CSV of All Candidates and send to admin
        public async Task<string> CandidateCSV(IEnumerable<Candidate> candidate)
        {
            using StringWriter stringWriter = new StringWriter();
            using CsvWriter csvWriter = new CsvWriter(stringWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteField("No.");
            csvWriter.WriteField("Candidate Name");
            csvWriter.WriteField("Candidate Email");
            csvWriter.WriteField("Candidate About");
            csvWriter.WriteField("Candidate Experience");
            csvWriter.WriteField("Candidate Current Company");
            csvWriter.WriteField("Candidate Phone");
            csvWriter.WriteField("Candidate Location");
            csvWriter.WriteField("Candidate Experience Time");
            csvWriter.WriteField("Candidate Expected Salary");
            csvWriter.WriteField("Candidate Age");
            csvWriter.WriteField("Candidate Qualification");
            
            csvWriter.NextRecord();

            var index = 1;
            foreach (var item in candidate)
            {
                csvWriter.WriteField(index++);
                csvWriter.WriteField(item.Name);
                csvWriter.WriteField(item.Email);
                csvWriter.WriteField(item.AboutMe);
                csvWriter.WriteField(item.Experience);
                csvWriter.WriteField(item.CurrentCompany);
                csvWriter.WriteField(item.Phone);
                csvWriter.WriteField(item.Location);
                csvWriter.WriteField(item.ExperienceTime);
                csvWriter.WriteField(item.ExpectedSalary);
                csvWriter.WriteField(item.Age);
                csvWriter.WriteField(item.Qualification);

                csvWriter.NextRecord(); // Move to the next line
            }


            string csvData = stringWriter.ToString();
            Guid csvId = Guid.NewGuid();
            string filePath = "D:\\JobPortal\\src\\assets\\Images\\admin\\" + csvId + "allCandidates.csv";

            System.IO.File.WriteAllText(filePath, csvData);

            return filePath;
        }

        // Make CSV of All Employer and send to admin
        public async Task<string> EmployerCSV(IEnumerable<Employer> employer)
        {
            using StringWriter stringWriter = new StringWriter();
            using CsvWriter csvWriter = new CsvWriter(stringWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteField("No.");
            csvWriter.WriteField("Company Name");
            csvWriter.WriteField("Company Email");
            csvWriter.WriteField("Company About");
            csvWriter.WriteField("Company Founded");
            csvWriter.WriteField("Company Headquarters ");
            csvWriter.WriteField("Company Industry");
            csvWriter.WriteField("Company Website");
            csvWriter.WriteField("Company Size ");

            csvWriter.NextRecord();

            var index = 1;

            foreach (var item in employer)
            {
                csvWriter.WriteField(index++);
                csvWriter.WriteField(item.CompanyName);
                csvWriter.WriteField(item.CompanyEmail);
                csvWriter.WriteField(item.CompanyAbout);
                csvWriter.WriteField(item.Founded);
                csvWriter.WriteField(item.Headquarters);
                csvWriter.WriteField(item.Industry);
                csvWriter.WriteField(item.CompanyWebsite);
                csvWriter.WriteField(item.CompanySize);

                csvWriter.NextRecord(); // Move to the next line
            }


            string csvData = stringWriter.ToString();
            Guid csvId = Guid.NewGuid();
            string filePath = "D:\\JobPortal\\src\\assets\\Images\\admin" + csvId + ".csv";

            System.IO.File.WriteAllText(filePath, csvData);

            return filePath;
        }


        // Make CSV of All AppliedJobs and send to admin
        public async Task<string> AppliedJobsCSV(IEnumerable<AppliedJobs> appliedJobs)
        {
            using StringWriter stringWriter = new StringWriter();
            using CsvWriter csvWriter = new CsvWriter(stringWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteField("No.");
            csvWriter.WriteField("Job Title");
            csvWriter.WriteField("Candidate Name");
            csvWriter.WriteField("Company Name");
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
            
            csvWriter.WriteField("Candidate Email");
            csvWriter.WriteField("Candidate About");
            csvWriter.WriteField("Candidate Experience");
            csvWriter.WriteField("Candidate Current Company");
            csvWriter.WriteField("Candidate Phone");
            csvWriter.WriteField("Candidate Location");
            csvWriter.WriteField("Candidate Experience Time");
            csvWriter.WriteField("Candidate Expected Salary");
            csvWriter.WriteField("Candidate Age");
            csvWriter.WriteField("Candidate Qualification");


            csvWriter.NextRecord();

            var index = 1;
            foreach (var item in appliedJobs )
            {
                csvWriter.WriteField(index++);
                csvWriter.WriteField(item.Job.Title);
                csvWriter.WriteField(item.Candidate.Name);
                csvWriter.WriteField(item.Job.Employer.CompanyName);
                csvWriter.WriteField(item.Job.Description);
                csvWriter.WriteField(item.Job.Responsibility);
                csvWriter.WriteField(item.Job.Location);
                csvWriter.WriteField(item.Job.Type);
                csvWriter.WriteField(item.Job.Qualifications);
                csvWriter.WriteField(item.Job.Type);
                csvWriter.WriteField(item.Job.StartBudget);
                csvWriter.WriteField(item.Job.EndBudget);
                csvWriter.WriteField(item.Job.JobExperience);
                csvWriter.WriteField(item.Job.JobShift);
                csvWriter.WriteField(item.Job.JobStatus);

                csvWriter.WriteField(item.Candidate.Email);
                csvWriter.WriteField(item.Candidate.AboutMe);
                csvWriter.WriteField(item.Candidate.Experience);
                csvWriter.WriteField(item.Candidate.CurrentCompany);
                csvWriter.WriteField(item.Candidate.Phone);
                csvWriter.WriteField(item.Candidate.Location);
                csvWriter.WriteField(item.Candidate.ExperienceTime);
                csvWriter.WriteField(item.Candidate.ExpectedSalary);
                csvWriter.WriteField(item.Candidate.Age);
                csvWriter.WriteField(item.Candidate.Qualification);

                csvWriter.NextRecord(); // Move to the next line
            }


            string csvData = stringWriter.ToString();
            Guid csvId = Guid.NewGuid();
            string filePath = "D:\\JobPortal\\src\\assets\\Images\\admin" + csvId + "allAppliedJobs.csv";

            System.IO.File.WriteAllText(filePath, csvData);

            return filePath;
        }


        // Make CSV of All Published Jobs and send to company
        public async Task<string> JobsCSV(List<Job> job)
        {
            using StringWriter stringWriter = new StringWriter();
            using CsvWriter csvWriter = new CsvWriter(stringWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteField("No.");
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

            var index = 1;

            foreach (var item in job)
            {
                csvWriter.WriteField(index++);
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
            string filePath = "D:\\JobPortal\\src\\assets\\Images\\CSV\\" + csvId + ".csv";

            System.IO.File.WriteAllText(filePath, csvData);

            return filePath;
        }

        
           
    }
}
