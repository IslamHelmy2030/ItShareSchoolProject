using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using School.DataLayer.Entities.Abstraction;

namespace School.DataLayer.Entities
{
    [Table("Subject")]
    public class Subject : BaseEntity
    {
        public virtual ICollection<SubjectLevel> SubjectLevels { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
