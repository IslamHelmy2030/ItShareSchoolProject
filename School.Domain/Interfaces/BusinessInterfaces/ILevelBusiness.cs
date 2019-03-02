using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Interfaces.BusinessInterfaces
{
    public interface ILevelBusiness
    {
        Task<IEnumerable<ILevelDto>> GetAllLevels();
        Task<ILevelDto> GetLevel(int id);
        Task<bool> AddLevel(LevelParameter levelName);
        Task<bool> UpdateLevel(LevelDto levelParameter);
        Task<bool> DeleteLevel(int id);
    }
}
