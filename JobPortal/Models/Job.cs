using JobPortal.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Icon { get; set; } 
        [Required]
        public string Title { get; set; } 
        [Required]
        public string Description { get; set; } 
        [Required]
        public string Responsibility { get; set; }
        [Required]
        public Location Location { get; set; }
        [Required]
        public JobType Type { get; set; }
        [Required]
        public Qualification Qualifications { get; set; }
        [Required]
        public SalaryType SalaryType { get; set; }
        [Required]
        [DisplayName("Start Budget")]
        public double StartBudget { get; set; }
        [Required]
        [DisplayName("End Budget")]
        public double EndBudget { get; set; }
        
        [Required]
        public JobExperience JobExperience { get; set; }
        [Required]
        public JobShift JobShift { get; set; }
        [Required]
        public JobStatus JobStatus { get; set; }

        [Required]
        public DateTime DeadLine { get; set; }
        public DateTime JobPosted { get; set; } = DateTime.Now;

        [Required]
        public int Vacancy { get; set; }
        public int EmployerId { get; set; }
        [ForeignKey(nameof(EmployerId))]
        public Employer? Employer { get; set; }

        public ICollection<JobSkills>? JobSkills { get; set; }
        public ICollection<AllJobsClasses>? AllJobsClasses { get; set; }
    }
}
