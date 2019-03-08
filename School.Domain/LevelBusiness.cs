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
    public class LevelBusiness : BaseBusiness<Level>, ILevelBusiness
    {
        public LevelBusiness(IUnitOfWork<Level> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<ILevelDto>> GetAllLevels()
        {
            var levels = await UnitOfWork.Repo.GetAll();
            var levelDtos = Mapper.Map<IEnumerable<Level>, IEnumerable<LevelDto>>(levels);
            return levelDtos;
        }

        public async Task<ILevelDto> GetLevel(int id)
        {
            var level = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == id);
            var levelDto = Mapper.Map<Level, LevelDto>(level);
            return levelDto;
        }

        public async Task<bool> AddLevel(LevelParameter levelName)
        {
            var level = Mapper.Map<LevelParameter, Level>(levelName);
            UnitOfWork.Repo.Add(level);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> UpdateLevel(LevelDto levelDto)
        {
            var level = Mapper.Map<ILevelDto, Level>(levelDto);
            UnitOfWork.Repo.Update(level);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteLevel(int id)
        {
            UnitOfWork.Repo.Remove(x => x.Id == id);
            return await UnitOfWork.SaveChanges() > 0;
        }
    }
}
