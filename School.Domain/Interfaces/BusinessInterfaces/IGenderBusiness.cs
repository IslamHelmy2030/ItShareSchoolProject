using System.Collections.Generic;
using System.Threading.Tasks;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Interfaces.BusinessInterfaces
{
    public interface IGenderBusiness
    {
        Task<IEnumerable<IGenderDto>> GetAllGenders();
        Task<IGenderDto> GetGender(int id);
        Task<bool> AddGender(GenderParameter genderName);
        Task<bool> UpdateGender(GenderDto genderParameter);
        Task<bool> DeleteGender(int id);
    }
}
