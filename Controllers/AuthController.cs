using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Faruk_NET_6_WEB_API_MVC_Projekat.Data;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.User;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
       public AuthController(IAuthRepository authRepo)
       {
            _authRepo = authRepo;
        
       }
       [HttpPost("register")]
       public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
       {
         var response=await _authRepo.Register(
             new User{Username=request.Username},request.Password
         );
         if(!response.Success)
         {
            return BadRequest(response);
         }
         return Ok(response);
       }

        [HttpPost("login")]
       public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
       {
         var response=await _authRepo.Login(request.Username, request.Password);
         if(!response.Success)
         {
            return BadRequest(response);
         }
         return Ok(response);
       }
    }
}