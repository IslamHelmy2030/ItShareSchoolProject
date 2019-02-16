using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Dto.Parameters
{
    public class LevelParameter
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Level Name is Required")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Invalid Level Name Length")]
        public string LevelName { get; set; }
    }
}
