using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Interfaces.DtoInterfaces
{
    public interface ILevelDto
    {
        int LevelId { get; set; }
        string LevelName { get; set; }
    }
}
