using System;
using System.Collections.Generic;
using System.Text;
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
    public class TeacherBusiness : BaseBusiness<Teacher> , ITeacherBusiness
    {
        public TeacherBusiness(IUnitOfWork<Teacher> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<ITeacherDto>> GetAllTeachers()
        {
            var teachers = await UnitOfWork.Repo.GetAll(inc1 => inc1.Subject, inc2 => inc2.TeacherClassRooms);
            var teacherDtos = Mapper.Map<IEnumerable<Teacher>, IEnumerable<ITeacherDto>>(teachers);
            return teacherDtos;
        }

        public async Task<ITeacherDto> GetTeacher(int id)
        {
            var teacher = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == id, inc1 => inc1.TeacherClassRooms
                , inc2 => inc2.TeacherClassRooms);
            var teacherDto = Mapper.Map<Teacher, ITeacherDto>(teacher);
            return teacherDto;
        }

        public async Task<IEnumerable<ITeacherDto>> GetAllTeachers(int subjectId)
        {
            var teachers = await UnitOfWork.Repo.Find(X => X.SubjectId == subjectId,
                inc1 => inc1.Subject, inc2 => inc2.TeacherClassRooms);
            var teacherDtos = Mapper.Map < IEnumerable<Teacher>, IEnumerable< TeacherDto >> (teachers);
            return teacherDtos;
        }

        public async Task<IEnumerable<ITeacherDto>> GetAllTeachByGender(int genderId)
        {
            var teachers = await UnitOfWork.Repo.Find(X => X.GenderId == genderId,
                inc1 => inc1.Subject, inc2 => inc2.TeacherClassRooms);
            var teacherDtos = Mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherDto>>(teachers);
            return teacherDtos;
        }

        public async Task<bool> AddTeacher(TeacherParameter teacherParameter)
        {
            var teacher = Mapper.Map<TeacherParameter, Teacher>(teacherParameter);
            UnitOfWork.Repo.Add(teacher);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> UpdateTeacher(TeacherDto teacherDto)
        {
            var teacher = Mapper.Map<TeacherDto, Teacher>(teacherDto);
            UnitOfWork.Repo.Update(teacher);
            return await UnitOfWork.SaveChanges() > 0;
        }
    

        public async Task<bool> DeleteTeacher(int id)
        {
          UnitOfWork.Repo.Remove(X=> X.Id== id);
          return await UnitOfWork.SaveChanges() > 0;
         }
    }
}
