using System.Collections.Generic;
using System.Threading.Tasks;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Interfaces.BusinessInterfaces
{
    public interface IStudentBusiness
    {
        Task<IEnumerable<IStudentDto>> GetAllStudents();
        Task<IStudentDto> GetStudent(int id);
        Task<IEnumerable<IStudentDto>> GetAllStudents(int classRoomId);
        Task<IEnumerable<IStudentDto>> GetAllStudentsByGender(int genderId);
        Task<bool> AddStudent(StudentParameter studentParameter);
        Task<bool> UpdateStudent(StudentDto studentDto);
        Task<bool> DeleteStudent(int id);
    }
}
