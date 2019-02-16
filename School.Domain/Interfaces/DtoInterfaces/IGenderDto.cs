using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Interfaces.DtoInterfaces
{
    public interface IGenderDto
    {
        int GenderId { get; set; }
        string GenderType { get; set; }
    }
}
