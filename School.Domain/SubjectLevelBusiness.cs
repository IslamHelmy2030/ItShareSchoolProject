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
    public class SubjectLevelBusiness : BaseBusiness<SubjectLevel>, ISubjectLevelBusiness
    {
        public SubjectLevelBusiness(IUnitOfWork<SubjectLevel> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public async Task<IEnumerable<ISubjectLevelDto>> GetAllSubjectLevel()
        {
            var subjectLevels = await UnitOfWork.Repo.GetAll(inc1 => inc1.SubjectId, inc2 => inc2.LevelId);
            var SubjectLevelDtos = Mapper.Map<IEnumerable<SubjectLevel>, IEnumerable<ISubjectLevelDto>>(subjectLevels);
            return SubjectLevelDtos;
        }

        public async Task<ISubjectLevelDto> GetSubjectLevel(int id)
        {
            var subjectlevel = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == id,
              inc1 => inc1.SubjectId, inc2 => inc2.LevelId);
            var subjectlevelDto = Mapper.Map<SubjectLevel, ISubjectLevelDto>(subjectlevel);
            return subjectlevelDto;
        }

        public async Task<IEnumerable<ISubjectLevelDto>> GetAllSubjectLevelByLevel(int LevelID)
        {
            var subjectlevels = await UnitOfWork.Repo.Find(x => x.LevelId == LevelID,
              inc1 => inc1.SubjectId, inc2 => inc2.LevelId);
            var subjectlevelDtos = Mapper.Map<IEnumerable<SubjectLevel>, IEnumerable<ISubjectLevelDto>>(subjectlevels);
            return subjectlevelDtos;
        }

        public async Task<IEnumerable<ISubjectLevelDto>> GetAllSubjectLevelBySubject(int SubjectID)
        {
            var subjectlevels = await UnitOfWork.Repo.Find(x => x.SubjectId == SubjectID,
              inc1 => inc1.SubjectId, inc2 => inc2.LevelId);
            var subjectlevelDtos = Mapper.Map<IEnumerable<SubjectLevel>, IEnumerable<ISubjectLevelDto>>(subjectlevels);
            return subjectlevelDtos;
        }

        public async Task<bool> AddSubjectLevel(SubjectLevelParameter subjectLevelParameter)
        {
            var subjectlevel = Mapper.Map<SubjectLevelParameter, SubjectLevel>(subjectLevelParameter);
            UnitOfWork.Repo.Add(subjectlevel);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> UpdateSubjectLevel(SubjectLevelDto subjectLevelDto)
        {
            var subjectlevel = Mapper.Map<SubjectLevelDto, SubjectLevel>(subjectLevelDto);
            UnitOfWork.Repo.Update(subjectlevel);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteSubjectLevel(int id)
        {
            UnitOfWork.Repo.Remove(x => x.Id == id);
            return await UnitOfWork.SaveChanges() > 0;
        }
    }
}
