using System.ComponentModel.DataAnnotations;

namespace School.Domain.Dto.Parameters
{
    public class UserLoginParameter
    {
        [Required]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
