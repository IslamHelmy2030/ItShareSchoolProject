using System;
using System.Collections.Generic;
using System.Text;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class SubjectLevelDto : SubjectLevelParameter , ISubjectLevelDto
    {
        public int SubjectLevelId { get; set; }
    }
}
