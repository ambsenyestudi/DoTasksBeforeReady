using Microsoft.AspNetCore.Mvc;
using StarwarsTheme.Application.DTO;
using StarwarsTheme.Application.Films;
using System.Collections.Generic;

namespace StarwarsTheme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmService filmService;

        public FilmsController(IFilmService filmService)
        {
            this.filmService = filmService;
        }
        [HttpGet]
        public IEnumerable<FilmDTO> List()
        {
            return filmService.GetAll();
        }
    }
}
