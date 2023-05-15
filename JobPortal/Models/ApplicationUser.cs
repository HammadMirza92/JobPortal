using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? EmployerId { get; set; }
        [ForeignKey(nameof(EmployerId))]
        public Employer? Employer { get; set; }
        public Guid? CandidateId { get; set; }
        [ForeignKey(nameof(CandidateId))]
        public Candidate? Candidate { get; set; }
    }
}
