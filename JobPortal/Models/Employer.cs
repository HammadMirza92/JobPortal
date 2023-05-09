using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAbout { get; set; }
        public string CompanyLogo { get; set; }
        public DateTime Founded { get; set; } = DateTime.MaxValue;
        public string Headquarters { get; set; }
        public string Industry { get; set; }
        public string CompanyWebsite { get; set; }
        public int CompanySize { get; set; }
        public ICollection<Job>? JobOffered { get; set; }
        public string UserId { get; set; }
        /*public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }*/

    }
}
