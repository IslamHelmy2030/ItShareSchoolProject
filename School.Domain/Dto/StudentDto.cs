using System;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class StudentDto : StudentParameter, IStudentDto
    {
        public int StudentId { get; set; }
    }

}
