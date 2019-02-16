using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.DataLayer.Entities
{
    [Table("TeacherClassRoom")]
    public class TeacherClassRoom
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [ForeignKey("ClassRoom")]
        public int ClassRoomId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
    }
}
