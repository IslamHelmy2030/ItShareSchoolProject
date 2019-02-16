using School.DataLayer.Entities.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.DataLayer.Entities
{
    [Table("Student")]
    public class Student : Person
    {
        [ForeignKey("ClassRoom")]
        public int ClassRoomId { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
    }
}
