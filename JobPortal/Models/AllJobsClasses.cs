using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class AllJobsClasses
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int JobClassId { get; set; }
        public JobClass JobClass { get; set; }
    }
}
