using System.Collections.Generic;
using System.Threading.Tasks;
using School.DataLayer.Entities;
using School.Domain.Abstraction;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;
using School.Repositories.UnitOfWork;

namespace School.Domain
{
    public class GenderBusiness : BaseBusiness<Gender>, IGenderBusiness
    {
        public GenderBusiness(IUnitOfWork<Gender> unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IList<GenderDto>> GetAllGenders()
        {
            var genders = await UnitOfWork.Repo.GetAll();
            var genderDtos = GetGenderDtos(genders);
            return genderDtos;
        }

        public async Task<GenderDto> GetGender(int id)
        {
            var gender = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == id);
            var genderDto = GetGenderDto(gender);
            return genderDto;
        }

        public async Task<bool> AddGender(GenderNameParameter genderName)
        {
            var gender = GetGender(genderName);
            UnitOfWork.Repo.Add(gender);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> UpdateGender(GenderParameter genderParameter)
        {
            var gender = GetGender(genderParameter);
            UnitOfWork.Repo.Update(gender);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteGender(int id)
        {
            UnitOfWork.Repo.Remove(x=>x.Id == id);
            return await UnitOfWork.SaveChanges() > 0;
        }

        private Gender GetGender(GenderNameParameter genderName)
        {
            return new Gender
            {
                Name = genderName.GenderType
            };
        }
        private Gender GetGender(GenderParameter genderParameter)
        {
            return new Gender
            {
                Id = genderParameter.GenderId,
                Name = genderParameter.GenderType
            };
        }

        private GenderDto GetGenderDto(Gender gender)
        {
            return new GenderDto
            {
                GenderId = gender.Id,
                GenderType = gender.Name
            };
        }

        private IList<GenderDto> GetGenderDtos(IList<Gender> genders)
        {
            var genderDtos = new List<GenderDto>();
            foreach (var gender in genders)
            {
                genderDtos.Add(GetGenderDto(gender));
            }

            return genderDtos;
        }
    }
}
