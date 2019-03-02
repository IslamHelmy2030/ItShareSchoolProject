using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Interfaces.DtoInterfaces
{
    public interface ITeacherDto
    {
        int TeacherId { get; set; }
        string TeacherName { get; set; }
        string TeacherAddress { get; set; }
        DateTime TeacherDateTime { get; set; }
        string TeacherPhone { get; set; }
        int GenderId { get; set; }
        string GenderName { get; set; }
        int SubjectId { get; set; }
        string SubjectName { get; set; }
    }
}
