using StarwarsTheme.Application.DTO;
using System.Collections.Generic;

namespace StarwarsTheme.Application.Films
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository repository;
        private readonly IFilmMappingService mappingService;

        public FilmService(IFilmRepository repository, IFilmMappingService mappingService)
        {
            this.repository = repository;
            this.mappingService = mappingService;
        }
        public List<FilmDTO> GetAll()
        {
            var filmsCollection = repository.GetAll();
            return mappingService.ToFilmDTO(filmsCollection);
        }
    }
}
