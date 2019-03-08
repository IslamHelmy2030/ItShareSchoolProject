using System;
using System.Collections.Generic;
using System.Text;
using School.DataLayer.Entities;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;

namespace School.Domain.Mapping
{
    public partial class AutoMapperProfile
    {
        private void SubjectMapping()
        {
            CreateMap<SubjectDto, Subject>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<SubjectParameter, Subject>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
