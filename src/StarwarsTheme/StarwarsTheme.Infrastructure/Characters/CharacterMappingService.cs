using AutoMapper;
using StarwarsTheme.Application.Characters;
using StarwarsTheme.Domain.Characters;
using StarwarsTheme.Infrastructure.Characters.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Infrastructure.Characters
{
    public class CharacterMappingService : ICharacterMappingService
    {
        private readonly IMapper mapper;

        public CharacterMappingService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public List<CharacterDTO> ToCharacterDTO(CharacterCollection characterCollection)
        {
            var resultList = new List<CharacterDTO>();
            var characterList = characterCollection.ToList();
            for (int i = 0; i < characterList.Count; i++)
            {
                var character = characterList[i];
                var characterDTO = mapper.Map<CharacterDTO>(character.Info);
                characterDTO.Id = mapper.Map<string>(character.Id);
                resultList.Add(characterDTO);
            }
            return resultList;
        }
            
        public CharacterCollection ToCharaterCollection(StarwarsCharacterResponse characterResponse)
        {
            var charList = characterResponse.Results.Select(ch => new Character(new CharacterId(Guid.NewGuid()), new CharacterInfo(ch.Name, ch.EyeColor)));
            return new CharacterCollection(charList);
        }
    }
}
