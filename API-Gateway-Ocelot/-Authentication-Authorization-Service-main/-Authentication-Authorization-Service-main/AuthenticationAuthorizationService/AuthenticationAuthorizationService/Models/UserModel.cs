using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationAuthorizationService.Models
{
    public class UserModel:IdentityUser
    {
        public DateTime CreatedDate { get;set; }

    }
}