using StarwarsTheme.Application.DTO;
using StarwarsTheme.Domain.Films;
using System.Collections.Generic;

namespace StarwarsTheme.Application.Films
{
    public interface IFilmMappingService
    {
        List<FilmDTO> ToFilmDTO(FilmCollection filmCollection);
    }
}
