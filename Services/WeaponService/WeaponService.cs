using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using AutoMapper;
using Faruk_NET_6_WEB_API_MVC_Projekat.Data;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Character;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Weapon;
using Microsoft.EntityFrameworkCore;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Services.WeaponService
{
    public class WeaponService : IWeaponSevice
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _maper;
        public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper maper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _maper = maper;
            
        }

        public async  Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            ServiceResponse<GetCharacterDto> response=new ServiceResponse<GetCharacterDto>();

          try
          {
                 Character character=await _context.Characters
                   .FirstOrDefaultAsync(c=>c.Id==newWeapon.CharacterId &&
                   c.User.Id==int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

                 if(character==null)
                 {
                    response.Success=false;
                    response.Message="Character not found";
                    return response;
                 }  
                 Weapon weapon=new Weapon
                  {
                    Name=newWeapon.Name,
                    Damage=newWeapon.Damage,
                    Character=character
                  };

                  _context.Weapon.Add(weapon);
                  await _context.SaveChangesAsync();
                  
                  response.Data=_maper.Map<GetCharacterDto>(character);

          }
          catch(Exception ex)
          {
            response.Success=false;
            response.Message=ex.Message;
          }    
          return response; 
        }
    }
}