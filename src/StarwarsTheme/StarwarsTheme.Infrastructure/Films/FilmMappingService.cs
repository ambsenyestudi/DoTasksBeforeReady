using AutoMapper;
using StarwarsTheme.Application.DTO;
using StarwarsTheme.Application.Films;
using StarwarsTheme.Domain.Films;
using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Infrastructure.Films
{
    public class FilmMappingService : IFilmMappingService
    {
        private readonly IMapper mapper;

        public FilmMappingService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public List<FilmDTO> ToFilmDTO(FilmCollection filmCollection)
        {
            var resultList = new List<FilmDTO>();
            var filmList = filmCollection.AsEnumerable().ToList();
            for (int i = 0; i < filmList.Count; i++)
            {
                var film = filmList[i];
                var currDTO = mapper.Map<FilmDTO>(film.Info);
                currDTO.Id = mapper.Map<string>(film.Id);
                resultList.Add(currDTO);
            }
            return resultList;
        }
    }
}
