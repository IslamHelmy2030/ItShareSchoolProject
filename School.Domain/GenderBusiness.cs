using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        public GenderBusiness(IUnitOfWork<Gender> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IList<GenderDto>> GetAllGenders()
        {
            var genders = await UnitOfWork.Repo.GetAll();
            var genderDtos = Mapper.Map<IList<Gender>, IList<GenderDto>>(genders);
            return genderDtos;
        }

        public async Task<GenderDto> GetGender(int id)
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

        //private Gender GetGender(GenderNameParameter genderName)
        //{
        //    return new Gender
        //    {
        //        Name = genderName.GenderType
        //    };
        //}
        //private Gender GetGender(GenderParameter genderParameter)
        //{
        //    return new Gender
        //    {
        //        Id = genderParameter.GenderId,
        //        Name = genderParameter.GenderType
        //    };
        //}

        //private GenderDto GetGenderDto(Gender gender)
        //{
        //    return new GenderDto
        //    {
        //        GenderId = gender.Id,
        //        GenderType = gender.Name
        //    };
        //}

        //private IList<GenderDto> GetGenderDtos(IList<Gender> genders)
        //{
        //    var genderDtos = new List<GenderDto>();
        //    foreach (var gender in genders)
        //    {
        //        genderDtos.Add(GetGenderDto(gender));
        //    }

        //    return genderDtos;
        //}
    }
}
