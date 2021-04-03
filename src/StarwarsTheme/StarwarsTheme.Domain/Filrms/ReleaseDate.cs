using System;
using System.Globalization;

namespace StarwarsTheme.Domain.Filrms
{
    public record ReleaseDate
    {
        public static string REALEASE_DATE_FORMAT = "yyyy-MM-dd";
        private const int FIRST_SOUND_FILM_YEAR = 1927;
        public DateTime Value { get; }
        private ReleaseDate(DateTime value) => (Value) = (value);

        public static ReleaseDate Create(DateTime dateTime)
        {
            EnsuerValidDate(dateTime);
            return new ReleaseDate(dateTime);
        }
        public static ReleaseDate Parse(string input)
        {
            var date = DateTime.ParseExact(input,
               REALEASE_DATE_FORMAT,
               CultureInfo.InvariantCulture);
            return Create(date);
        }
        private static void EnsuerValidDate(DateTime dateTime)
        {
            if (dateTime.Year < FIRST_SOUND_FILM_YEAR || dateTime > DateTime.Now)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
