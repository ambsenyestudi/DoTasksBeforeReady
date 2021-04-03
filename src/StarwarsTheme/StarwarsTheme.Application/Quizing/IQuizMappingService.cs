using StarwarsTheme.Application.DTO;
using StarwarsTheme.Domain.Quizing.FilmYears;

namespace StarwarsTheme.Application.Quizing
{
    public interface IQuizMappingService
    {
        FilmYearQuestionDTO ToQuestion(FilmYearQuiz quiz);
    }
}
