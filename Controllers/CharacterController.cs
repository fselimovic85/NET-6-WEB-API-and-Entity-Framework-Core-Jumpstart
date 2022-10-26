using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Faruk_NET_6_WEB_API_MVC_Projekat.Services.CharacterServices;
using Faruk_NET_6_WEB_API_MVC_Projekat.Dtos.Character;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Controllers

{   //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    
    public class CharacterController:ControllerBase
    {
       
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
           
        }
       // [AllowAnonymous]
        [HttpGet("GetAll")]

        /* Ovako treba da se uradi u kodu kod Patrika, medjutim kod mene to nece iz nekog razloga da radi
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {   
            var userId=int.Parse(User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.NameIdentifier).Value);
            return Ok(await _characterService.GetAllCharacters(userId));
        }
        */

        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {   
           
            return Ok(await _characterService.GetAllCharacters());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
           return Ok(await _characterService.GetCharacterById(id));
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id)
        {
             var response=await _characterService.DeleteCharacter(id);
            if(response.Data==null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        //[AllowAnonymous]           
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            
            return Ok( await _characterService.AddCaracter(newCharacter));
        }

         [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {            
            var response=await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data==null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            return Ok(await _characterService.AddCharacterSkill(newCharacterSkill));
        }
    }
}