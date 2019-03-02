using System;
using System.Collections.Generic;
using System.Text;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class TeacherDto : TeacherParameter  , ITeacherDto
    {
        public  int TeacherId { get; set; }
    }
}
