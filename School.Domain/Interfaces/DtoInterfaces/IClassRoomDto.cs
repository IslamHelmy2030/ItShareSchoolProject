namespace School.Domain.Interfaces.DtoInterfaces
{
    public interface IClassRoomDto
    {
        int ClassRoomId { get; set; }
        string ClassRoomName { get; set; }
        int LevelId { get; set; }
        string LevelName { get; set; }
    }
}
