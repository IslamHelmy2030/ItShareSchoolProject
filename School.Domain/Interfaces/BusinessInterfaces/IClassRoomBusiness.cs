using System.Collections.Generic;
using System.Threading.Tasks;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Interfaces.BusinessInterfaces
{
    public interface IClassRoomBusiness
    {
        Task<IEnumerable<IClassRoomDto>> GetAllClassRooms();
        Task<IClassRoomDto> GetClassRoom(int id);
        Task<bool> AddClassRoom(ClassRoomParameter classRoomParameter);
        Task<bool> UpdateClassRoom(ClassRoomDto classRoomDto);
        Task<bool> DeleteClassRoom(int id);
    }
}
