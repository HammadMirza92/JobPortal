using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Employeer
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAbout { get; set; }
        public string CompanyLogo { get; set; }
        public DateTime Founded { get; set; }
        public string Headquarters { get; set; }
        public string Industry { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyEmail { get; set; }
        public int CompanySize { get; set; }
        public ICollection<Job> JobOffered { get; set; }
    }
}
