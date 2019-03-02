using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Dto.Parameters
{
    public class SubjectLevelParameter
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int LevelId { get; set; }
        public string LevelName { get; set; }
    }
}
