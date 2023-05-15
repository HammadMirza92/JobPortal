using JobPortal.Models.ModelBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class JobSkills: BaseModel
    {
        public Guid JobId { get; set; }
        [ForeignKey(nameof(JobId))]
        public Job Job { get; set; }
        public Guid SkillId { get; set; }
        [ForeignKey(nameof(SkillId))]
        public Skills Skill { get; set; }
    }
}
