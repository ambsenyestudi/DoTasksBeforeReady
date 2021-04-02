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

        private CharacterCollection cache;
        private readonly IStarwarsCharactersGateway gateway;
        private readonly IMapper mapper;

        public InMemoryCharacterRepository(
            IStarwarsCharactersGateway gateway,
            IMapper mapper)
        {
            this.gateway = gateway;
            this.mapper = mapper;
            var guid = Guid.NewGuid();
            var list = new List<Character> { new Character(new CharacterId(guid), new CharacterInfo("Luck", "Blue")) };
            cache = new CharacterCollection(list);
        }

        

        public CharacterCollection GetAll()
        {
            return cache;
        }

        public async Task UpdateRepositoryAsync(CancellationToken cancellationToken)
        {
            var response = await gateway.GetAll(cancellationToken);
            var list = response.Results
                .Select(swCh => 
                    new Character(new CharacterId(Guid.NewGuid()), 
                    mapper.Map<CharacterInfo>(swCh)));
            cache = new CharacterCollection(list);
        }

    }
}
