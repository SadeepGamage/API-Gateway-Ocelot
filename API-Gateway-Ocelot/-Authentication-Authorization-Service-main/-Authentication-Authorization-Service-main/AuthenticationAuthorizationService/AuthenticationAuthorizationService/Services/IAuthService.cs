using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationAuthorizationService.DTOs;
using AuthenticationAuthorizationService.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationAuthorizationService.Services
{
    public interface IAuthService
    {
        Task<IdentityResult>Register(RegisterModel  registerModel);
        Task<string>Login(LoginModel loginModel);
    }
}