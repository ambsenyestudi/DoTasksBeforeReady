using StarwarsTheme.Application.DTO;
using System.Collections.Generic;

namespace StarwarsTheme.Application.Films
{
    public interface IFilmService
    {
        List<FilmDTO> GetAll();
    }
}
