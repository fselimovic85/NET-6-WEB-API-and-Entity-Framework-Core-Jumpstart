using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Character;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Fight;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Skill;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Weapon;

namespace Faruk_NET_6_WEB_API_MVC_Projekat
{
    public class AutoMapperProfile: Profile
    { 
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto > ();
            CreateMap<Weapon, GetWeaponDto> ();
            CreateMap<Character, HighscoreDto>();

        }  
        
    }
}