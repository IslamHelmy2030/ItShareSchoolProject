using System.Collections.Generic;
using System.Threading.Tasks;
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
        public LevelBusiness(IUnitOfWork<Level> unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IList<ILevelDto>> GetAllLevels()
        {
            var levels = await UnitOfWork.Repo.GetAll();
            return GetLevelDtos(levels);
        }

        public async Task<ILevelDto> GetLevel(int id)
        {
            var level = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == id);
            return GetLevelDto(level);
        }

        public async Task<bool> AddLevel(LevelParameter levelName)
        {
            UnitOfWork.Repo.Add(GetLevel(levelName));
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> UpdateLevel(LevelDto levelParameter)
        {
            UnitOfWork.Repo.Update(GetLevel(levelParameter));
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteLevel(int id)
        {
            UnitOfWork.Repo.Remove(x => x.Id == id);
            return await UnitOfWork.SaveChanges() > 0;
        }

        private Level GetLevel(LevelParameter levelParameter)
        {
            return new Level
            {
                Name = levelParameter.LevelName
            };
        }

        private Level GetLevel(ILevelDto levelParameter)
        {
            return new Level
            {
                Id = levelParameter.LevelId,
                Name = levelParameter.LevelName
            };
        }

        private ILevelDto GetLevelDto(Level level)
        {
            return new LevelDto
            {
                LevelId = level.Id,
                LevelName = level.Name
            };
        }

        private IList<ILevelDto> GetLevelDtos(IList<Level> levels)
        {
            IList<ILevelDto> levelDtos = new List<ILevelDto>();
            foreach (var level in levels)
            {
                ILevelDto levelDto = GetLevelDto(level);
                levelDtos.Add(levelDto);
            }

            return levelDtos;
        }
    }
}
