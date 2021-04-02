using StarwarsTheme.Domain.Filrms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Domain.Quizing
{
    public class CharacterFilmQuiz
    {
        public QuizId Id { get; }

        private readonly string characterName;

        public QuizCharacterFilmAnswerCollection Answers { get; }

        public CharacterFilmQuiz(string characterName, IEnumerable<Film> filmCollection, Guid id = default(Guid))
        {
            EnsuerFilms(filmCollection);
            
            if (id == default(Guid))
            {
                id = Guid.NewGuid();
            }
            Id = new QuizId(id);

            this.characterName = characterName;
            this.Answers = new QuizCharacterFilmAnswerCollection(filmCollection, Id);
        }

        public QuizCharacterFilmAnswerCollection GetAnswers()
        {
            return Answers;
        }
        public void EnsuerFilms(IEnumerable<Film> films)
        {
            if(films == null || !films.Any())
            {
                throw new ArgumentException();
            }
        }
    }
}
