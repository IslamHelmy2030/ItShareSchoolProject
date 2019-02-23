using System.Collections.Generic;
using System.Threading.Tasks;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;

namespace School.Domain.Interfaces.BusinessInterfaces
{
    public interface IGenderBusiness
    {
        Task<IList<GenderDto>> GetAllGenders();
        Task<GenderDto> GetGender(int id);
        Task<bool> AddGender(GenderParameter genderName);
        Task<bool> UpdateGender(GenderDto genderParameter);
        Task<bool> DeleteGender(int id);
    }
}
