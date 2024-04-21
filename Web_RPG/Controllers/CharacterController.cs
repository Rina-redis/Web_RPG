using Microsoft.AspNetCore.Mvc;
using Web_RPG.Models;
using Web_RPG.Services.CharacterService;

namespace Web_RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
     
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
           _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Character>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

    }
}
 