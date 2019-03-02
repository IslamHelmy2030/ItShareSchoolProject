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
        private void LevelMapping()
        {
            CreateMap<LevelDto, Level>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LevelId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LevelName))
                .ReverseMap();

            CreateMap<LevelParameter, Level>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LevelName));
        }
    }
}
