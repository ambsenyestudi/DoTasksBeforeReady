using System;
using System.Globalization;

namespace StarwarsTheme.Domain.Filrms
{
    public record FilmInfo
    {

        public static string REALEASE_DATE_FORMAT= "yyyy-MM-dd";

        public string Title { get; }

        public int EpisodeId { get; }

        public string Director { get; }

        public DateTime ReleaseDate { get; }

       

        public FilmInfo(string title, string director, int episodeId,  DateTime releaseDate) => (Title, EpisodeId, Director, ReleaseDate) = (title, episodeId, director, releaseDate);

        public static DateTime StringToReleaseDate(string input) =>
            DateTime.ParseExact(input,
                REALEASE_DATE_FORMAT,
                CultureInfo.InvariantCulture);

    }
}
