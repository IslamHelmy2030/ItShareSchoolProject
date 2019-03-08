using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class TeacherClassRoomDto : ITeacherClassRoomDto
    {
        public int TeacherClassRoomId { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int ClassRoomId { get; set; }
        public int ClassRoomName { get; set; }

    }
}
