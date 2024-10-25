using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
// using AuthenticationAuthorizationService.Models;
using AuthenticationAuthorizationService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationAuthorizationService.Services
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IConfiguration _config;

        public async Task<string> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))

            {
                return null; // Authentication failed
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JWt:Secrect"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                    new Claim(ClaimTypes.Email , user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key) , SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<IdentityResult> Register(RegisterModel registerModel)
        {
            if(registerModel.Password != registerModel.ConfirmPassword)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Password do not much"});

            }
            var user = new UserModel { Email =registerModel.Email };
            var result = await _userManager.CreateAsync(user , registerModel.Password);
            return result;
        }
    }
}