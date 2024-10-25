using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.DTOs
{
    public class UserDTO
    {
        public int UserId { get;set; }
        public string Name { get;set; }
        public string Email { get;set; }
        public string Bio {get;set;}
        public DateTime CreatedDate { get;set; }
    }
}