using AutoMapper;
using StarwarsTheme.Application.DTO;
using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Films;
using StarwarsTheme.Infrastructure.Films.Models;

namespace StarwarsTheme.Infrastructure.Mapping.Profiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            //This does not work
            /*
            CreateMap<StarwarsFilm, FilmInfo>()
                .ForMember(fi => fi.ReleaseDate,
                opt => opt.MapFrom(src => ReleaseDate.Parse(src.ReleaseDate)));
            */
            CreateMap<StarwarsFilm, FilmInfo>();
            CreateMap<string, ReleaseDate>().ConvertUsing(str => ReleaseDate.Parse(str));
            CreateMap<ReleaseDate, string>().ConvertUsing(rd => rd.Value.ToString(ReleaseDate.REALEASE_DATE_FORMAT));
            CreateMap<FilmInfo, FilmDTO>();
            CreateMap<FilmId, string>().ConvertUsing(fId => fId.Value.ToString());
        }
    }
}
