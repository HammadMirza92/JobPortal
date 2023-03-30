using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class JobApplications
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public IFormFile CV { get; set; }
    }
}
