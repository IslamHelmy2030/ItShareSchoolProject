using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.DataLayer.Entities;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Mapping
{
    public partial class AutoMapperProfile
    {
        private void GenderMapping()
        {
            //CreateMap<IGenderDto, Gender>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GenderId))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GenderType))
            //    .ReverseMap();

            CreateMap<GenderDto, Gender>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GenderId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GenderType))
                .ReverseMap();

            CreateMap<GenderParameter, Gender>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GenderType));
        }



    }
}
