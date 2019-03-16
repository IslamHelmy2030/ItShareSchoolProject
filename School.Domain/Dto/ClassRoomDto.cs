using System.ComponentModel.DataAnnotations;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class ClassRoomDto : IClassRoomDto
    {
        public int ClassRoomId { get; set; }

        [Display(Name = "Class Name")]
        public string ClassRoomName { get; set; }

        [Display(Name = "Level")]
        public int LevelId { get; set; }

        [Display(Name = "Level Name")]
        public string LevelName { get; set; }
    }
}
