using System.Threading.Tasks;
using School.Domain.Dto.Parameters;

namespace School.Domain.Interfaces.BusinessInterfaces
{
    public interface IAccountBusiness
    {
        Task<string> Login(UserLoginParameter loginParameter);
        Task<string> InsertUser(UserRegisterParameter registerParameter);
    }
}
