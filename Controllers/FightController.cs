using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Fight;
using Faruk_NET_6_WEB_API_MVC_Projekat.Services.FightService;
using Microsoft.AspNetCore.Mvc;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController:ControllerBase
    {
        private readonly IFightService _flyService;
        public FightController(IFightService fightService)
        {
            _flyService = fightService;
        }

        [HttpGet("Weapon")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>>WeaponAttack(WeaponAttackDto request)
        {
            return Ok(await _flyService.WeaponAttack(request));
        }

        [HttpGet("Skill")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> SkillAttack(SkillAttackDto request)
        {
            return Ok(await _flyService.SkilAttack(request));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<FightResultDto>>> Fight(FightRequestDto request)
        {
            return Ok(await _flyService.Fight(request));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<HighscoreDto>>> GetHighscore()
        {
            return Ok(await _flyService.GetHighscore());
        }






    }
}
