using JobPortal.Enums;

namespace JobPortal.Models
{
    public class SearchJobs
    {
        public string? Title { get; set; }
        public Location? Location { get; set; }
        public JobType? Type { get; set; }
        public Qualification? Qualification { get; set; }
        public SalaryType? SalaryType { get; set; }
        public int? StartBudget { get; set; }
        public int? EndBudget { get; set; }
        public JobExperience? JobExperience { get; set; }
        public JobShift? JobShift { get; set; }
    }
}
