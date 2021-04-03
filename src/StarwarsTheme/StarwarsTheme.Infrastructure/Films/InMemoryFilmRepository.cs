using AutoMapper;
using StarwarsTheme.Application.Films;
using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Characters;
using StarwarsTheme.Domain.Filrms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StarwarsTheme.Infrastructure.Films
{
    public class InMemoryFilmRepository : IFilmRepository
    {
        private readonly IStarwarsCharactersGateway gateway;
        private readonly IMapper mapper;
        private FilmCollection inMemoryList;
        public LastUpdated LastUpdated => LastUpdated.Never;
        public InMemoryFilmRepository(IStarwarsCharactersGateway gateway,
            IMapper mapper)
        {
            this.gateway = gateway;
            this.mapper = mapper;
            var guid = new Guid("7e613b56-aa04-4a95-841f-cce7c28cd9d4");
            var list = new List<Film> { new Film(new FilmId(guid), new FilmInfo("A new hope", "George Lucas", 3, ReleaseDate.Parse("1977-05-25"))) };
            inMemoryList = new FilmCollection(list);
        }

        public async Task UpdateRepositoryAsync(CancellationToken cancellationToken)
        {
            var response = await gateway.GetAllFilmsAsync(cancellationToken);
            var list = response.Results
                .Select(swCh =>
                    new Film(new FilmId(Guid.NewGuid()),
                    mapper.Map<FilmInfo>(swCh)));
            inMemoryList = new FilmCollection(list);
        }

        public FilmCollection GetAll() =>
            inMemoryList;
    }
}
