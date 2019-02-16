using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using School.DataLayer.Entities.Abstraction;

namespace School.DataLayer.Entities
{
    [Table("Gender")]
    public class Gender : BaseEntity
    {

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
