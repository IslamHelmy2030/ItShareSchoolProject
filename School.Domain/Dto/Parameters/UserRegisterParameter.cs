using System.ComponentModel.DataAnnotations;

namespace School.Domain.Dto.Parameters
{
    public class UserRegisterParameter : UserLoginParameter
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
