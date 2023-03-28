using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
