using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Faruk_NET_6_WEB_API_MVC_Projekat.Services.WeaponService;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Character;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Weapon;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeaponController:ControllerBase
    {
        public readonly IWeaponSevice _weaponService;
       public WeaponController(IWeaponSevice weaponService)
       {
            _weaponService = weaponService;
        
       }   
       [HttpPost]
       public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddWeapon(AddWeaponDto newWeapon)
       {
         return Ok(await _weaponService.AddWeapon(newWeapon));
       }
    }
}