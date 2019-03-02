using System;
using System.Collections.Generic;
using System.Text;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class SubjectDto : ISubjectDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
