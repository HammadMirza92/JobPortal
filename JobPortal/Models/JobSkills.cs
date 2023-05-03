using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class JobSkills
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        [ForeignKey(nameof(JobId))]
        public Job Job { get; set; }
        public int SkillId { get; set; }
        [ForeignKey(nameof(SkillId))]
        public Skills Skill { get; set; }
    }
}
