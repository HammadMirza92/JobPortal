using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class JobSkills
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int SkillId { get; set; }
        public Skills Skill { get; set; }
    }
}
