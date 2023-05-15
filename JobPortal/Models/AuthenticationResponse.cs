using Microsoft.AspNetCore.Identity;

namespace JobPortal.Models
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public IdentityUser User { get; set; }
        public string Role { get; set; }
        public Guid? EmployerId { get; set; }
        public Employer? Employer { get; set; }
        public Guid? CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
        public DateTime Expiration { get; set; }
    }
}
