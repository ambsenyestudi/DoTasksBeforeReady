using System;

namespace StarwarsTheme.Domain.Filrms
{
    public record FilmInfo
    {
        public string Title { get; }
        
        public FilmId FilmId { get; }

        public string Director { get; }

        public DateTime ReleaseDate { get; }

        public FilmInfo(string title, FilmId filmId, string director, DateTime releaseDate) => (Title, FilmId, Director, ReleaseDate) = (title, filmId, director, releaseDate);

        //todo use dateformat
        public static bool TryParseDate(string input, out DateTime releaseDate, string dateFromat = "yyyy-MM-dd") =>
            DateTime.TryParse(input, out releaseDate);
    }
}
