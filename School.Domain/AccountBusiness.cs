using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;

namespace School.Domain
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountBusiness(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> Login(UserLoginParameter loginParameter)
        {
            try
            {
                if (loginParameter == null)
                {
                    return "Something went wrong";
                }

                var user = await IsValidateUser(loginParameter);
                if (user == null)
                {
                    return "Wrong Username Or Password";
                }

                var userLoginReturn = GenerateJsonWebToken(user);
                return userLoginReturn;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> InsertUser(UserRegisterParameter registerParameter)
        {
            try
            {
                if (registerParameter == null)
                {
                    return "Something went wrong";
                }

                var user = new IdentityUser { UserName = registerParameter.UserName, Email = registerParameter.Email, SecurityStamp = new Guid().ToString() };

                var result = await _userManager.CreateAsync(user, registerParameter.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return "Saved Successfully";
                }
                return "Something went wrong";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private async Task<IdentityUser> IsValidateUser(UserLoginParameter loginParameter)
        {
            var user = await _userManager.FindByNameAsync(loginParameter.UserName);

            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginParameter.Password, false);
            if (result.Succeeded)
            {
                return user;
            }

            return null;
        }

        private string GenerateJsonWebToken(IdentityUser userInfo)
        {
            var claims = new[] {
                new Claim( JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("UserId", userInfo.Id)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SaraAmroMohammedMoamen"));
            var expiryInHours = DateTime.Now.AddHours(24);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: "www.Yahoo.com",
                audience: "www.google.com",
                expires: expiryInHours,
                signingCredentials: credentials,
                claims: claims);

            string userToken = new JwtSecurityTokenHandler().WriteToken(token);
            return userToken;
        }
    }
}
