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
        private void SubjectLevelMapping()
        {
            CreateMap<SubjectLevel, SubjectLevelDto>()
                .ForMember(dest => dest.SubjectLevelId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.LevelId, opt => opt.MapFrom(src => src.LevelId))
                .ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.Level.Name))
                .ReverseMap();

            CreateMap<SubjectLevelParameter, SubjectLevel>();             
        }
    }
}
