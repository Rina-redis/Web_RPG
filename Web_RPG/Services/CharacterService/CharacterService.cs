global using AutoMapper;
using Web_RPG.DTOs.Character;
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
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var serviceResp = new ServiceResponse<List<GetCharacterDTO>>();

            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(x => x.Id) + 1;
            characters.Add(character);

            serviceResp.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResp;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            var serviceResp = new ServiceResponse<List<GetCharacterDTO>>();
            serviceResp.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResp;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {

            var serviceResp = new ServiceResponse<GetCharacterDTO>();
            var character = characters.FirstOrDefault(obj => obj.Id == id);
            serviceResp.Data = _mapper.Map<GetCharacterDTO>(character);
            return serviceResp;

        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            try
            {
                var character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);

                character.Name = updateCharacter.Name;
                character.HP = updateCharacter.HP;
                character.Strength = updateCharacter.Strength;
                character.Defencse = updateCharacter.Defencse;
                character.Intelligence = updateCharacter.Intelligence;
                character.Class = updateCharacter.Class;

                serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
            }
            catch (NullReferenceException ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;

            }
            return serviceResponse;
        }
    }
}
