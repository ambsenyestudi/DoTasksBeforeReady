using AutoMapper;
using StarwarsTheme.Application.Characters;
using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StarwarsTheme.Infrastructure.Characters
{

    public class InMemoryCharacterRepository : ICharacterRepository
    {
        public LastUpdated LastUpdated { get; private set; } = LastUpdated.Never;

        private CharacterCollection inMemoryList;
        private readonly IStarwarsCharactersGateway gateway;
        private readonly IMapper mapper;

        public InMemoryCharacterRepository(
            IStarwarsCharactersGateway gateway,
            IMapper mapper)
        {
            this.gateway = gateway;
            this.mapper = mapper;
            var guid = Guid.NewGuid();
            var list = new List<Character> { new Character(new CharacterId(guid), CharacterInfo.Create("Luck", "Blue")) };
            inMemoryList = new CharacterCollection(list);
        }

        

        public CharacterCollection GetAll() => 
            inMemoryList;

        public async Task UpdateRepositoryAsync(CancellationToken cancellationToken)
        {
            var response = await gateway.GetAllCharactersAsync(cancellationToken);
            var list = response.Results
                .Select(swCh => 
                    new Character(new CharacterId(Guid.NewGuid()), 
                    mapper.Map<CharacterInfo>(swCh)));
            inMemoryList = new CharacterCollection(list);
        }

    }
}
