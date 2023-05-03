using Microsoft.AspNetCore.Identity;

namespace JobPortal.Models
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public IdentityUser User { get; set; }
        public string Role { get; set; }
        public int? EmployeerId { get; set; }
        public Employer? Employeer { get; set; }
        public DateTime Expiration { get; set; }
    }
}
