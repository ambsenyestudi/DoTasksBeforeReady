using StarwarsTheme.Domain.Characters;
using StarwarsTheme.Domain.Films;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Domain.Quizing
{
    public class CharacterFilmQuiz
    {
        public QuizId Id { get; }

        private readonly Character character;

        public QuizCharacterFilmAnswerCollection Answers { get; }

        internal CharacterFilmQuiz(Character character, IEnumerable<Film> filmCollection, QuizId id)
        {
            

            Id = id;
            this.character = character;
            this.Answers = new QuizCharacterFilmAnswerCollection(filmCollection, Id);
        }

        public QuizCharacterFilmAnswerCollection GetAnswers()
        {
            return Answers;
        }
        
    }
}
