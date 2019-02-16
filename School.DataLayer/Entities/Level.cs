using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using School.DataLayer.Entities.Abstraction;

namespace School.DataLayer.Entities
{
    [Table("Level")]
    public class Level : BaseEntity
    {
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
        public virtual ICollection<SubjectLevel> SubjectLevels { get; set; }
    }
}
