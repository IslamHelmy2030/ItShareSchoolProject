using System.ComponentModel.DataAnnotations;

namespace School.Domain.Dto.Parameters
{
    public class ClassRoomParameter
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Class Room Name Is Required"), Display(Name = "Class Name")]
        public string ClassRoomName { get; set; }

        [Display(Name = "Level")]
        [Required(ErrorMessage = "Level Is Required")]
        public int LevelId { get; set; }
    }
}
