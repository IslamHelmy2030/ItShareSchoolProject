using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Interfaces.BusinessInterfaces
{
    public interface ITeacherBusiness 
    {
        Task<IEnumerable<ITeacherDto>> GetAllTeachers();
        Task<ITeacherDto> GetTeacher(int id);
        Task<IEnumerable<ITeacherDto>> GetAllTeachers(int subjectId);
        Task<IEnumerable<ITeacherDto>> GetAllTeachByGender(int genderId);
        Task<bool> AddTeacher(TeacherParameter teacherParameter);
        Task<bool> UpdateTeacher(TeacherDto teacherDto);
        Task<bool> DeleteTeacher(int id);
    }
}
