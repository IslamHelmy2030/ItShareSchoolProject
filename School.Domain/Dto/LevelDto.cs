using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class LevelDto : ILevelDto
    {
        public int LevelId { get; set; }
        public string LevelName { get; set; }
    }
}
