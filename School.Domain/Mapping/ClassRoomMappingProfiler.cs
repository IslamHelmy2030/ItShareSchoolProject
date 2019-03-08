using School.DataLayer.Entities;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;

namespace School.Domain.Mapping
{
    public partial class AutoMapperProfile
    {
        private void ClassRoomMapping()
        {
            CreateMap<ClassRoomDto, ClassRoom>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClassRoomId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ClassRoomName))
                .ReverseMap();

            CreateMap<ClassRoomParameter, ClassRoom>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ClassRoomName))
                .ForMember(dest => dest.LevelId, opt => opt.MapFrom(src => src.LevelId));
        }



    }
}
