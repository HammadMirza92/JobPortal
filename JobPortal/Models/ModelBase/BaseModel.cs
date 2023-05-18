using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models.ModelBase
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
