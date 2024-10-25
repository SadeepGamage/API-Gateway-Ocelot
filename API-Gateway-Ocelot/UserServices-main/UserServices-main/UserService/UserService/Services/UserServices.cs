using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using UserService.DTOs;
using UserService.Mappers;
using UserService.Models;
using UserService.Repositories;

namespace UserService.Services
{
    public class UserServices:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository =userRepository;
        }

        public async Task AddUserAsync(UserModel userModel)
        {
            await _userRepository.AddUserAsync(userModel);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUserAsync();
            return users;
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user;
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
            // return user;
        }

        public async Task UpdateUserAsync(int id, UserModel userModel)
        {
            var user  = await _userRepository.GetUserByIdAsync(id);
            if(user != null)
            {
                user.Name = userModel.Name;
                user.Email = userModel.Email;
                user.Bio = userModel.Bio;
                user.PasswordHash = userModel.PasswordHash;
                await _userRepository.UpdateUserAsync(user);
            }
        }
    }
}