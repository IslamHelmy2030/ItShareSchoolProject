using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Dto.Parameters
{
    public class GenderParameter : GenderNameParameter
    {
        [Required(ErrorMessage = "Gender Id Is Required")]
        public int GenderId { get; set; }
    }
}
