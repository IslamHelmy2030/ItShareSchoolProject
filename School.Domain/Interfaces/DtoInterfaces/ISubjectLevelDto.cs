using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Interfaces.DtoInterfaces
{
    public interface ISubjectLevelDto
    {
        int SubjectLevelId { get; set; }
        int SubjectId { get; set; }
        string SubjectName { get; set; }
        int LevelId { get; set; }
        string LevelName { get; set; }
    }
}
