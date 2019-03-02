using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Interfaces.DtoInterfaces
{
    public interface IStudentDto
    {
        int StudentId { get; set; }
        string StudentName { get; set; }
        string StudentAddress { get; set; }
        DateTime StudentBirthDate { get; set; }
        string StudentPhone { get; set; }
        int GenderId { get; set; }
        string GenderName { get; set; }
        int ClassRoomId { get; set; }
        string ClassName { get; set; }
    }
}
