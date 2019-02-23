using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Dto.Parameters
{
    public class GenderParameter
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "Gender Type is Required")]
        [StringLength(10,MinimumLength = 4,ErrorMessage = "Invalid Gender Type Length")]
        public string GenderType { get; set; }
    }
}
