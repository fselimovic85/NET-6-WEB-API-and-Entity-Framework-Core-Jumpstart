using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Fight;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);

        Task<ServiceResponse<AttackResultDto>> SkilAttack(SkillAttackDto request);

        Task<ServiceResponse<FightResultDto>> Fight(FightRequestDto request);

        Task<ServiceResponse<List<HighscoreDto>>> GetHighscore();


    }
}
