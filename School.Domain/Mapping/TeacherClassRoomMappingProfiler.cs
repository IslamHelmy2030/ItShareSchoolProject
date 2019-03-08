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
        private void TeacherClassRoomMapping()
        {
            CreateMap<TeacherClassRoomDto,TeacherClassRoom>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TeacherClassRoomId))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                //.ForMember(dest => dest.Teacher.Name, opt => opt.MapFrom(src => src.TeacherName))
                .ForMember(dest => dest.ClassRoomId, opt => opt.MapFrom(src => src.ClassRoomId))
                //.ForMember(dest => dest.ClassRoom.Name, opt => opt.MapFrom(src => src.ClassRoomName))
                .ReverseMap();


            CreateMap<TeacherClassRoomParameter, TeacherClassRoom>()
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.ClassRoomId, opt => opt.MapFrom(src => src.ClassRoomId));

        }

    }
}
