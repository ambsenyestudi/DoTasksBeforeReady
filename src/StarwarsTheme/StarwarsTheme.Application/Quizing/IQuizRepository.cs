using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Quizing.CharacterEyeColors;
using StarwarsTheme.Domain.Quizing.FilmYears;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StarwarsTheme.Application.Quizing
{
    public interface IQuizRepository
    {
        LastUpdated LastUpdated { get; }
        Task UpdateRepositoryAsync(CancellationToken cancellationToken);
        IEnumerable<FilmYearQuiz> GetAllYearFilms();
        FilmYearQuiz GetFilmYearQuizBy(QuizId id);
        IEnumerable<CharacterEyeColorQuiz> GetAllCharactersEyeColor();
        CharacterEyeColorQuiz GetCharacterEyeColorQuizBy(QuizId quizId);
    }
}
