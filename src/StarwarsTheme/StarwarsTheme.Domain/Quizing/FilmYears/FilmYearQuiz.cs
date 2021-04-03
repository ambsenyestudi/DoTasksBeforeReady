using StarwarsTheme.Domain.Films;

namespace StarwarsTheme.Domain.Quizing.FilmYears
{
    public record FilmYearQuiz
    {
        private const string HEADING_TEMPLATE = "On what year was {0} released?";
        public QuizId Id { get; }
        public string Heading { get; set; } 
        private FilmYearAnswer Answer { get; }

        internal FilmYearQuiz(QuizId id, Film film) 
        {
            Id = id;
            Heading = string.Format(HEADING_TEMPLATE, film.Info.Title);
            Answer = new FilmYearAnswer(id, film);
        }
        public bool IsCorrectAnswer(FilmYearAnswer filmYearAnswer)
        {
            if(filmYearAnswer.Id != Answer.Id)
            {
                filmYearAnswer = new FilmYearAnswer(Answer.Id, filmYearAnswer.Year);
            }
            return Answer == filmYearAnswer;
        }
    }
}
