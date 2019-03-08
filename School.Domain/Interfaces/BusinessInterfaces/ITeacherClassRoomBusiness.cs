using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Domain.Interfaces.BusinessInterfaces
{
    public interface ITeacherClassRoomBusiness
    {
        Task<IEnumerable<ITeacherClassRoomDto>> GetAllTeacherClassRooms();
        Task<ITeacherClassRoomDto> GetTeacherClassRoom(int id);
        Task<bool> AddTeacherClassRoom(TeacherClassRoomParameter teacherClassRoomParameter);
        Task<bool> UpdateTeacherClassRoom(TeacherClassRoomDto teacherClassRoomDto);
        Task<bool> DeleteTeacherClassRoom(int id);


    }
}
