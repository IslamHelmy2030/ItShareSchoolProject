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
    public class GenderBusiness : BaseBusiness<Gender>, IGenderBusiness
    {
        public GenderBusiness(IUnitOfWork<Gender> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<IGenderDto>> GetAllGenders()
        {
            var genders = await UnitOfWork.Repo.GetAll();
            var genderDtos = Mapper.Map<IEnumerable<Gender>, IEnumerable<GenderDto>>(genders);
            return genderDtos;
        }

        public async Task<IGenderDto> GetGender(int id)
        {
            var gender = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == id);
            var genderDto = Mapper.Map<Gender, GenderDto>(gender);
            return genderDto;
        }

        public async Task<bool> AddGender(GenderParameter genderName)
        {
            var gender = Mapper.Map<GenderParameter, Gender>(genderName);
            UnitOfWork.Repo.Add(gender);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> UpdateGender(GenderDto genderDto)
        {
            var gender = Mapper.Map<GenderDto, Gender>(genderDto);
            UnitOfWork.Repo.Update(gender);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteGender(int id)
        {
            UnitOfWork.Repo.Remove(x => x.Id == id);
            return await UnitOfWork.SaveChanges() > 0;
        }
    }
}
