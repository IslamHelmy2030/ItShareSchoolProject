using AutoMapper;

namespace School.Domain.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            LevelMapping();
            GenderMapping();
            StudentMapping();

        }




    }
}
