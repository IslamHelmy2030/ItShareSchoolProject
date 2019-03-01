using System.ComponentModel.DataAnnotations;

namespace School.Domain.Dto.Parameters
{
    public class GenderParameter
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender Type is Required")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Invalid Gender Type Length")]
        public string GenderType { get; set; }
    }
}
