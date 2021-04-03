using StarwarsTheme.Domain.Characters;
using StarwarsTheme.Domain.Films;
using StarwarsTheme.Domain.Quizing.FilmYears;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Domain.Quizing
{
    public class Quiz
    {
        public static FilmYearQuiz CreateFilmYearQuiz(QuizId id, Film film)
        {
            return new FilmYearQuiz(id, film);
        }
        public static CharacterFilmQuiz CreateCharacterFilmQuiz(Character character, IEnumerable<Film> filmCollection, QuizId id)
        {
            EnsureCharacter(character);
            EnsuerFilms(filmCollection);


            return new CharacterFilmQuiz(character, filmCollection, id);
        }

        private static void EnsureCharacter(Character character)
        {
            if(character == null || character.Info == null)
            {
                throw new ArgumentException();
            }
        }

        private static void EnsuerFilms(IEnumerable<Film> films)
        {
            if (films == null || !films.Any())
            {
                throw new ArgumentException();
            }
        }
    }
}
