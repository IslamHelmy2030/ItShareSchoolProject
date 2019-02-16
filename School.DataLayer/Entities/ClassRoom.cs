using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using School.DataLayer.Entities.Abstraction;

namespace School.DataLayer.Entities
{
    [Table("ClassRoom")]
    public class ClassRoom : BaseEntity
    {
        [ForeignKey("Level")]
        public int LevelId { get; set; }

        public virtual Level Level { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TeacherClassRoom> TeacherClassRooms { get; set; }
    }
}
