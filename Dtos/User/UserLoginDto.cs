using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.User
{
    public class UserLoginDto
    {
        public string Username { get; set; }=string.Empty;
        public string Password { get; set; }=string.Empty;
    }
}