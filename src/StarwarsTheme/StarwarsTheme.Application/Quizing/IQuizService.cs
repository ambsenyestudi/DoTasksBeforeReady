using StarwarsTheme.Application.DTO;
using System.Collections.Generic;

namespace StarwarsTheme.Application.Quizing
{
    public interface IQuizService
    {
        List<QuizQuestionDTO> GetFilmYearQuestions();
        bool EvaluateFilmYearAnswer(FilmYearAnswerDTO answer);
        IEnumerable<QuizQuestionDTO> GetCharacterEyeColorQuestions();
    }
}
