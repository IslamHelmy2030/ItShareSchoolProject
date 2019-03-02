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
        private void TeacherMapping()
        {

            CreateMap<Teacher, TeacherDto>()
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TeacherAddress, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.TeacherDateTime, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.TeacherPhone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Gender.Name))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ReverseMap();


            CreateMap<TeacherParameter, Teacher>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TeacherName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.TeacherAddress))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.TeacherDateTime))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.TeacherPhone));



        }
    }
}
