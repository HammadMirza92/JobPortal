using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? EmployeerId { get; set; }
        [ForeignKey(nameof(EmployeerId))]
        public Employer? Employeer { get; set; }
    }
}
