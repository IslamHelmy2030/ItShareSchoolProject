using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using School.DataLayer.Entities.Abstraction;

namespace School.DataLayer.Entities
{
    [Table("Teacher")]
    public class Teacher : Person
    {
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<TeacherClassRoom> TeacherClassRooms { get; set; }
    }
}
