using Microsoft.AspNetCore.Identity;

namespace JobPortal.Models
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public IdentityUser User { get; set; }
        public string Role { get; set; }
        public int? EmployerId { get; set; }
        public Employer? Employer { get; set; }
        public DateTime Expiration { get; set; }
    }
}
