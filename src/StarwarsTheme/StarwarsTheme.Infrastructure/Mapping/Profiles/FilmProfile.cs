using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using StarwarsTheme.Domain.Filrms;
using StarwarsTheme.Infrastructure.Films.Models;
using System;

namespace StarwarsTheme.Infrastructure.Mapping.Profiles
{
    public class FilmProfile : Profile
    {
        private const string dateFormat = "yyyy-MM-dd";
        public static readonly IsoDateTimeConverter dateConverter = new IsoDateTimeConverter { DateTimeFormat = dateFormat };
        public FilmProfile()
        {
            CreateMap<StarwarsFilm, FilmInfo>()
                .ForMember(fi => fi.Director,
                opt => opt.MapFrom(src =>src.Director))
                .ForMember(fi => fi.ReleaseDate,
                opt => opt.MapFrom(src => ToFormatedDateTime(src.ReleaseDate, dateConverter)));
        }
        private DateTime ToFormatedDateTime(string input, IsoDateTimeConverter converter) =>
            JsonConvert.DeserializeObject<DateTime>(input, converter);
    }
}
