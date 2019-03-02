using AutoMapper;
using School.DataLayer.Entities;
using School.Domain.Abstraction;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;
using School.Domain.Interfaces.DtoInterfaces;
using School.Repositories.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Domain
{
    public class TeacherClassRoomBusiness : BaseBusiness<TeacherClassRoom>, ITeacherClassRoomBusiness
    {
        public TeacherClassRoomBusiness(IUnitOfWork<TeacherClassRoom> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<ITeacherClassRoomDto>> GetAllTeacherClassRooms()
        {
            var classRooms = await UnitOfWork.Repo.GetAll(inc1 => inc1.Teacher, inc2 => inc2.ClassRoom);
            var classRoomDtos = Mapper.Map<IEnumerable<TeacherClassRoom>, IEnumerable<ITeacherClassRoomDto>>(classRooms);
            return classRoomDtos;
        }

        public async Task<ITeacherClassRoomDto> GetTeacherClassRoom(int id)
        {
            var classRoom = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == id, inc1 => inc1.Teacher, inc2 => inc2.ClassRoom);
            var classRoomDto = Mapper.Map<TeacherClassRoom, ITeacherClassRoomDto>(classRoom);
            return classRoomDto;
        }

        public async Task<bool> AddTeacherClassRoom(TeacherClassRoomParameter teacherClassRoomParameter)
        {
            var classRoom = Mapper.Map<TeacherClassRoomParameter, TeacherClassRoom>(teacherClassRoomParameter);
            UnitOfWork.Repo.Add(classRoom);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> UpdateTeacherClassRoom(TeacherClassRoomDto teacherClassRoomDto)
        {
            var classRoom = Mapper.Map<ITeacherClassRoomDto, TeacherClassRoom>(teacherClassRoomDto);
            UnitOfWork.Repo.Update(classRoom);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteTeacherClassRoom(int id)
        {
            UnitOfWork.Repo.Remove(x => x.Id == id);
            return await UnitOfWork.SaveChanges() > 0;
        }
    }
}
