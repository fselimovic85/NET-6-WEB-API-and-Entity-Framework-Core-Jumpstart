using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Character;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Weapon;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Services.WeaponService
{
    public interface IWeaponSevice
    {
       Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}