using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
namespace Faruk_NET_6_WEB_API_MVC_Projekat.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public IConfiguration _configuration;
         public AuthRepository(DataContext context, IConfiguration configuration)
         {
            _configuration = configuration;
            _context = context;
            
         }
        public async Task<ServiceResponse<string>> Login(string username, string passwprd)
        {
            var response=new ServiceResponse<string>();
            var user=await _context.Users.FirstOrDefaultAsync(u=>u.Username.ToLower().Equals(username.ToLower()));

            if(user==null)
            {
                response.Success=false;
                response.Message="User not found.";

            }else if(!VerifyPasswordHash(passwprd, user.PasswordHash, user.PasswordSalt))
            {
                response.Success=false;
                response.Message="Wrog password.";
            }else
            {
              response.Data=CreateToken(user); 
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string passwprd)
        {
          ServiceResponse<int> response=new ServiceResponse<int>();
          if(await UserExists(user.Username))
          {
            response.Success=false;
            response.Message="User already exists.";
            return response;
          }
          
          CreatePasswordHash(passwprd, out byte[] passwordHash, out byte[] passwordSalt);

          user.PasswordHash=passwordHash;
          user.PasswordSalt=passwordSalt;

           _context.Users.Add(user);
           await _context.SaveChangesAsync();
         
           response.Data=user.Id;
           return response;

        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(u=>u.Username.ToLower()==username.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string passwprd, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwprd));
            }
        }

         private bool VerifyPasswordHash (string passwprd, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwprd));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims=new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };
            SymmetricSecurityKey key=new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));
                
            SigningCredentials creds=new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor=new SecurityTokenDescriptor
            {
              Subject=new ClaimsIdentity(claims),
              Expires=DateTime.Now.AddDays(1),
              SigningCredentials=creds

            };
            JwtSecurityTokenHandler tokenHandler= new JwtSecurityTokenHandler();
            SecurityToken token=tokenHandler.CreateToken(tokenDescriptor); 

            return tokenHandler.WriteToken(token); //Token
        }
    }
}