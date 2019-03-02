using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class ClassRoomDto : IClassRoomDto
    {
        public int ClassRoomId { get; set; }
        public string ClassRoomName { get; set; }
        public int LevelId { get; set; }
        public string LevelName { get; set; }
    }
}
