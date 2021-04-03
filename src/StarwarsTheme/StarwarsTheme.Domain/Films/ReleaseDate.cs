using System;
using System.Globalization;

namespace StarwarsTheme.Domain.Films
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

        public int GetYear() =>
            Value.Year;

        public static ReleaseDate Parse(string input)
        {
            var date = DateTime.ParseExact(input,
               REALEASE_DATE_FORMAT,
               CultureInfo.InvariantCulture);
            return Create(date);
        }
        public static bool TryParse(string input, out ReleaseDate releaseDate)
        {
            var canParse = DateTime.TryParseExact(input, REALEASE_DATE_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);
            releaseDate =  canParse 
                ? new ReleaseDate(dateTime)
                : new ReleaseDate(new DateTime(FIRST_SOUND_FILM_YEAR,1, 1));
            return canParse;
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
