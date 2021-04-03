using StarwarsTheme.Domain.Films;

namespace StarwarsTheme.Domain.Quizing
{
    public record QuizCharacterFilmAnswer
    {
        public QuizId QuizId { get; }
        public FilmInfo FilmInfo { get; }
        public QuizCharacterFilmAnswer(QuizId quizId, FilmInfo filmInfo) => (QuizId, FilmInfo) = (quizId, filmInfo);
    }
}
