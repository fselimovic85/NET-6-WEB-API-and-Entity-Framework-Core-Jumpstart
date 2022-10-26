using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Skill;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Weapon;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name{ get; set; }="Frodo";
        public int HitPoints { get; set; }=100;
        public int Strength { get; set; }=10;
        public int Defense { get; set; }=10;
        public int Intellignesee { get; set; }=10;
        public RpgClass Class { get; set; }=RpgClass.Knight;
        public GetWeaponDto Weapon { get; set; }
        public List<GetSkillDto> Skils { get; set; }

        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }

}