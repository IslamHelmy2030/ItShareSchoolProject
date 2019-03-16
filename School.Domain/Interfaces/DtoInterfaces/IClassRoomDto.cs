using System.ComponentModel.DataAnnotations;

namespace School.Domain.Interfaces.DtoInterfaces
{
    public interface IClassRoomDto
    {
        int ClassRoomId { get; set; }

        [Display(Name = "Class Name")]
        string ClassRoomName { get; set; }

        [Display(Name = "Level")]
        int LevelId { get; set; }

        [Display(Name = "Level Name")]
        string LevelName { get; set; }
    }
}
