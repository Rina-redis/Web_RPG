using Web_RPG.DTOs.Character;
using Web_RPG.Models;

namespace Web_RPG
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO,Character>();
        }
    }
}
