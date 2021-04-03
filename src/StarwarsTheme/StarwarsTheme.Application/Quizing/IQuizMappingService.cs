using StarwarsTheme.Application.DTO;
using StarwarsTheme.Domain.Quizing.CharacterEyeColors;
using StarwarsTheme.Domain.Quizing.FilmYears;

namespace StarwarsTheme.Application.Quizing
{
    public interface IQuizMappingService
    {
        QuizQuestionDTO ToFilmYearQuestion(FilmYearQuiz quiz);
        QuizQuestionDTO ToCharacterEyeColorQuestion(CharacterEyeColorQuiz quiz);
    }
}
