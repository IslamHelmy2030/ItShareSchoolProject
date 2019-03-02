using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class SubjectLevelDto : SubjectLevelParameter, ISubjectLevelDto
    {
        public int SubjectLevelId { get; set; }
        public string SubjectName { get; set; }
        public string LevelName { get; set; }
    }
}
