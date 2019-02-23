using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class ClassRoomDto : IClassRoomDto
    {
        public int ClassRoomId { get; set; }
        public string ClassRoomName { get; set; }
        public string LevelName { get; set; }
    }
}
