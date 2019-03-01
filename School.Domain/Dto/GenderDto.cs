using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class GenderDto : GenderParameter, IGenderDto
    {
        public int GenderId { get; set; }
    }
}
