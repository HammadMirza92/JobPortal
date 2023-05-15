using JobPortal.Models.ModelBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class AllJobsClasses: BaseModel
    {
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public Guid JobClassId { get; set; }
        public JobClass JobClass { get; set; }
    }
}
