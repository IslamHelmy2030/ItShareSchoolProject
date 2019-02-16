using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Domain.Dto
{
    public class GenderDto : IGenderDto
    {
        public int GenderId { get; set; }
        public string GenderType { get; set; }
    }
}
