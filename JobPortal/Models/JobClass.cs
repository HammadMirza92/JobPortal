using JobPortal.Enums;
using JobPortal.Models.ModelBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class JobClass: BaseModel
    {
        public JobClasses name { get; set; }
        public ICollection<AllJobsClasses> AllJobsClasses { get; set; }
    }
}
