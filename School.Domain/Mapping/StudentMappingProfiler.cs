using School.DataLayer.Entities;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;

namespace School.Domain.Mapping
{
    public partial class AutoMapperProfile
    {
        private void StudentMapping()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StudentAddress, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.StudentBirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.StudentPhone, opt => opt.MapFrom(src => src.Phone))
                //.ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Gender.Name))
                //.ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.ClassRoom.Name))
                .ReverseMap();



            CreateMap<StudentParameter, Student>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StudentName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.StudentAddress))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.StudentBirthDate))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.StudentPhone));
        }
    }
}
