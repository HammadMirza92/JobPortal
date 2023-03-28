using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobStatus { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
