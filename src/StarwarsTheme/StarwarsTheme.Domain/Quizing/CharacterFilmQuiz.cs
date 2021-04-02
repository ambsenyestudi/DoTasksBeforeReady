using StarwarsTheme.Domain.Filrms;
using System;
using System.Collections.Generic;

namespace StarwarsTheme.Domain.Quizing
{
    public class CharacterFilmQuiz
    {
        public QuizId Id { get; }

        private readonly string characterName;

        public QuizCharacterFilmAnswerCollection Answers { get; }

        public CharacterFilmQuiz(string characterName, IEnumerable<Film> filmColleciton, Guid id = default(Guid))
        {
            if(id == default(Guid))
            {
                id = Guid.NewGuid();
            }
            Id = new QuizId(id);

            this.characterName = characterName;
            this.Answers = new QuizCharacterFilmAnswerCollection(filmColleciton, Id);
        }

        public QuizCharacterFilmAnswerCollection GetAnswers()
        {
            return Answers;
        }
    }
}
