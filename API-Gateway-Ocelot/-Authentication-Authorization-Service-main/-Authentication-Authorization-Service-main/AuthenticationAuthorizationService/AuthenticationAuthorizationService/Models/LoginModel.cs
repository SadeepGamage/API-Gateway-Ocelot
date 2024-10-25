using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAuthorizationService.Models
{
    public class LoginModel
    {
        [Key]
        public int LoginId { get;set; }
        public string Email{ get;set;}
        public string Password { get;set; }

    }
}