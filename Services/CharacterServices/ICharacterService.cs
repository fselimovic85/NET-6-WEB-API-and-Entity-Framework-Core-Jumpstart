using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Character;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Services.CharacterServices
{
    public interface ICharacterService
    {
       // Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters(int userId);
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCaracter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto);
        
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);

        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);   
        

        
    }
}