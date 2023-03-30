using JobPortal.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public int Vacancy { get; set; } 
        [Required]
        public string Description { get; set; } 
        [Required]
        public string Responsibility { get; set; } 
        [Required]
        public string Qualifications { get; set; } 
        [Required]
        public JobStatus Status { get; set; } 
        [Required]
        public JobType Type { get; set; } 
        [Required]
        [DisplayName("Company Detail")]
        public string CompanyDetail { get; set; } 

        [Required]
        [DisplayName("Start Budget")]
        public double StartBudget { get; set; }
        [Required]
        [DisplayName("End Budget")]
        public double EndBudget { get; set; }
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; } 
        [Required]
        public string Location { get; set; } 
    }
}
