using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using School.DataLayer.Entities;
using School.Domain.Abstraction;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;
using School.Domain.Interfaces.DtoInterfaces;
using School.Repositories.UnitOfWork;

namespace School.Domain
{
    public class ClassRoomBusiness : BaseBusiness<ClassRoom>, IClassRoomBusiness
    {
        public ClassRoomBusiness(IUnitOfWork<ClassRoom> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }


        public async Task<IEnumerable<IClassRoomDto>> GetAllClassRooms()
        {
            var classRooms = await UnitOfWork.Repo.GetAll(x => x.Level);
            var classRoomDtos = Mapper.Map<IEnumerable<ClassRoom>, IEnumerable<ClassRoomDto>>(classRooms);
            return classRoomDtos;
        }

        public async Task<IClassRoomDto> GetClassRoom(int id)
        {
            var classRoom = await UnitOfWork.Repo.FirstOrDefault(wre => wre.Id == id, inc => inc.Level);
            var classRoomDto = Mapper.Map<ClassRoom, IClassRoomDto>(classRoom);
            return classRoomDto;
        }

        public async Task<bool> AddClassRoom(ClassRoomParameter classRoomParameter)
        {
            var classRoom = Mapper.Map<ClassRoomParameter, ClassRoom>(classRoomParameter);
            UnitOfWork.Repo.Add(classRoom);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> UpdateClassRoom(ClassRoomDto classRoomDto)
        {
            var classRoom = Mapper.Map<IClassRoomDto, ClassRoom>(classRoomDto);
            UnitOfWork.Repo.Update(classRoom);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteClassRoom(int id)
        {
            UnitOfWork.Repo.Remove(x => x.Id == id);
            return await UnitOfWork.SaveChanges() > 0;
        }
    }
}
