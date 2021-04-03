using StarwarsTheme.Domain.Characters;
using StarwarsTheme.Domain.Films;
using StarwarsTheme.Domain.Quizing.CharacterEyeColors;
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
            EnsuerFilm(film);
            return new FilmYearQuiz(id, film);
        }
        public static CharacterEyeColorQuiz CreatecharacterEyeColorQuizDictionary(QuizId id, Character character)
        {
            EnsureCharacter(character);
            return new CharacterEyeColorQuiz(id, character);
        }
        private static void EnsureCharacter(Character character)
        {
            if(character == null || character.Info == null)
            {
                throw new ArgumentException();
            }
        }

        private static void EnsuerFilm(Film film)
        {
            if (film == null || film.Info == null)
            {
                throw new ArgumentException();
            }
        }

        
    }
}
