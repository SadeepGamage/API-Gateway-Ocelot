using System.Collections.Generic;
using UserService.DTOs;
using UserService.Models;

namespace UserService.Mappers
{
    public static class UserMapper
    {
        public static UserDTO MapToDTO(UserModel user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Bio = user.Bio
            };
        }

        public static UserModel MapToModel(UserDTO userDto)
        {
            return new UserModel
            {
                UserId = userDto.UserId,
                Name = userDto.Name,
                Email = userDto.Email,
                Bio = userDto.Bio
            };
        }

        public static IEnumerable<UserDTO> MapToDTOList(IEnumerable<UserModel> users)
        {
            var userList = new List<UserDTO>();
            foreach (var user in users)
            {
                userList.Add(MapToDTO(user));
            }
            return userList;
        }

        // internal static IEnumerable<UserDTO> MapToDTO(IEnumerable<UserModel> users)
        // {
        //     throw new NotImplementedException();
        // }

        // internal static async Task<UserDTO> MapToDTO(Task<UserModel> user)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
