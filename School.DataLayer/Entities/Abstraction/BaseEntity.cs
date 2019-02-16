using System.ComponentModel.DataAnnotations;

namespace School.DataLayer.Entities.Abstraction
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }
    }
}
