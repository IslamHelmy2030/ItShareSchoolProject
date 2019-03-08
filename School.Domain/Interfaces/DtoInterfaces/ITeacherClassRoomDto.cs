using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Interfaces.DtoInterfaces
{
    public interface ITeacherClassRoomDto
    {

        int TeacherClassRoomId { get; set; }
        int TeacherId { get; set; }
        string TeacherName { get; set; }
        int ClassRoomId { get; set; }

    }
}
