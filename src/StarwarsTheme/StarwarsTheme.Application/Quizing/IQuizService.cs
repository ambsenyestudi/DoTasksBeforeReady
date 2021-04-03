using StarwarsTheme.Application.DTO;
using System.Collections.Generic;

namespace StarwarsTheme.Application.Quizing
{
    public interface IQuizService
    {
        List<FilmYearQuestionDTO> GetQuestions();
    }
}
