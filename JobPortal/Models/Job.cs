using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string CompanyDetail { get; set; }
        public int Budget { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
    }
}
