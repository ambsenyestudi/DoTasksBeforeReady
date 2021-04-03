using StarwarsTheme.Domain.Films;

namespace StarwarsTheme.Domain.Quizing.FilmYears
{
    public record FilmYearAnswer
    {
        public QuizId Id { get; }
        public int Year { get; }

        public FilmYearAnswer(QuizId id, Film film)
        {
            Id = id;
            Year = film.Info.GetYearOfMaking();
        }
        public FilmYearAnswer(QuizId id, int year) => (Id, Year) = (id, year);
    }
}
