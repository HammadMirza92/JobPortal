using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class UserCradential
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
