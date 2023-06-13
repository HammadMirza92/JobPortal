using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class ConfirmEmail
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
