using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Dto.Parameters
{
    public class ClassRoomParameter
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "Class Room Name Is Required")]
        public string ClassRoomName { get; set; }
        public int LevelId { get; set; }
    }
}
