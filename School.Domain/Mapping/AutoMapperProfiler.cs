using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using School.DataLayer.Entities;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            LevelMapping();
            GenderMapping();


        }

        

        
    }
}
