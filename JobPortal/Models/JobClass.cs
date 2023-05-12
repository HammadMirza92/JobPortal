using JobPortal.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class JobClass
    {
        [Key]
        public int Id { get; set; }
        public JobClasses name { get; set; }
        public ICollection<AllJobsClasses> AllJobsClasses { get; set; }
    }
}
