using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;

namespace School.Api.Controllers
{
    /// <inheritdoc />
    public class AccountController : ControllerBase
    {
        private readonly IAccountBusiness _accountBusiness;

        /// <inheritdoc />
        public AccountController(IAccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPost(nameof(Login))]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]UserLoginParameter parameter)
        {
            var result = await _accountBusiness.Login(parameter);
            return Ok(result);
        }

        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPost(nameof(Register))]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]UserRegisterParameter parameter)
        {
            var result = await _accountBusiness.InsertUser(parameter);
            return Ok(result);
        }
    }
}
