using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class JobClass
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<AllJobsClasses> AllJobsClasses { get; set; }
    }
}
