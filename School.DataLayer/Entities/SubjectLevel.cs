using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.DataLayer.Entities
{
    [Table("SubjectLevel")]
    public class SubjectLevel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        [ForeignKey("Level")]
        public int LevelId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Level Level { get; set; }
    }
}
