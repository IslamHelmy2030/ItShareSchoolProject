using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Interfaces.BusinessInterfaces
{
    public interface ISubjectBusiness
    {
        Task<IEnumerable<ISubjectDto>> GetAllSubjects();
        Task<ISubjectDto> GetSubject(int id);
        Task<bool> AddSubject(SubjectParameter subjectName);
        Task<bool> UpdateSubject(SubjectDto subjectParameter);
        Task<bool> DeleteSubject(int id);

    }
}
