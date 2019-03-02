using School.Domain.Dto;
using School.Domain.Interfaces.DtoInterfaces;
using School.Domain.Dto.Parameters;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Interfaces.BusinessInterfaces
{
    public interface ISubjectLevelBusiness
    {
        Task<IEnumerable<ISubjectLevelDto>> GetAllSubjectLevel();
        Task<ISubjectLevelDto> GetSubjectLevel(int id);
        Task<IEnumerable<ISubjectLevelDto>> GetAllSubjectLevelBySubject(int SubjectID);
        Task<IEnumerable<ISubjectLevelDto>> GetAllSubjectLevelByLevel(int LevelID);
        Task<bool> AddSubjectLevel(SubjectLevelParameter sub);
        Task<bool> UpdateSubjectLevel(SubjectLevelDto subjectLevelDto);
        Task<bool> DeleteSubjectLevel(int id);
    }
}
