using Web_RPG.Models;

namespace Web_RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> 
        {
            new Character (),
            new Character{Id = 1,Name = "Sam"}
        };
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {
            var serviceResp = new ServiceResponse<List<Character>>();
            characters.Add(newCharacter);
            serviceResp.Data = characters;
            return serviceResp;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceResp = new ServiceResponse<List<Character>>();
            serviceResp.Data = characters;
            return serviceResp;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {

            var serviceResp = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(obj => obj.Id == id);
            serviceResp.Data = character;

            if (character != null)
            {
                return serviceResp;
            }
            throw new Exception("Not found");
        }
    }
}
