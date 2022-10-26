using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string passwprd);
        Task<ServiceResponse<string>> Login(string username, string passwprd);
        Task<bool> UserExists(string username);
        
    }
}