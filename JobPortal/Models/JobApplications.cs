using JobPortal.Models.ModelBase;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class JobApplications: BaseModel
    {
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public IFormFile CV { get; set; }
    }
}
