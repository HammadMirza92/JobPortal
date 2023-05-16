using JobPortal.Enums;

namespace JobPortal.Models.Dto
{
    public class JobDto
    {
        public IFormFile Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Responsibility { get; set; }
        public Location Location { get; set; }
        public JobType Type { get; set; }
        public Qualification Qualifications { get; set; }
        public SalaryType SalaryType { get; set; }
        public double StartBudget { get; set; }
        public double EndBudget { get; set; }
        public JobExperience JobExperience { get; set; }
        public JobShift JobShift { get; set; }
        public JobStatus JobStatus { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime JobPosted { get; set; } = DateTime.Now;
        public int Vacancy { get; set; }
        public Guid EmployerId { get; set; }
        public Employer? Employer { get; set; }

    }
}
