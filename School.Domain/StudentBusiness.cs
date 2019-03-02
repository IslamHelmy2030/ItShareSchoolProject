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
    public class StudentBusiness : BaseBusiness<Student>, IStudentBusiness
    {
        public StudentBusiness(IUnitOfWork<Student> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<IStudentDto>> GetAllStudents()
        {
            var students = await UnitOfWork.Repo.GetAll(inc1 => inc1.ClassRoom, inc2 => inc2.Gender);
            var studentDtos = Mapper.Map<IEnumerable<Student>, IEnumerable<IStudentDto>>(students);
            return studentDtos;
        }

        public async Task<IStudentDto> GetStudent(int id)
        {
            var student = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == id,
                inc1 => inc1.ClassRoom, inc2 => inc2.Gender);
            var studentDto = Mapper.Map<Student, IStudentDto>(student);
            return studentDto;
        }

        public async Task<IEnumerable<IStudentDto>> GetAllStudents(int classRoomId)
        {
            var students = await UnitOfWork.Repo.Find(x => x.ClassRoomId == classRoomId,
                inc1 => inc1.ClassRoom, inc2 => inc2.Gender);
            var studentDtos = Mapper.Map<IEnumerable<Student>, IEnumerable<IStudentDto>>(students);
            return studentDtos;
        }

        public async Task<IEnumerable<IStudentDto>> GetAllStudentsByGender(int genderId)
        {
            var students = await UnitOfWork.Repo.Find(x => x.GenderId == genderId,
                inc1 => inc1.ClassRoom, inc2 => inc2.Gender);
            var studentDtos = Mapper.Map<IEnumerable<Student>, IEnumerable<IStudentDto>>(students);
            return studentDtos;
        }

        public async Task<bool> AddStudent(StudentParameter studentParameter)
        {
            var student = Mapper.Map<StudentParameter, Student>(studentParameter);
            UnitOfWork.Repo.Add(student);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> UpdateStudent(StudentDto studentDto)
        {
            var student = Mapper.Map<StudentDto, Student>(studentDto);
            UnitOfWork.Repo.Update(student);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            UnitOfWork.Repo.Remove(x => x.Id == id);
            return await UnitOfWork.SaveChanges() > 0;
        }
    }
}
