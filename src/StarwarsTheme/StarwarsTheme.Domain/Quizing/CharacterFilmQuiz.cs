using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsTheme.Domain.Quizing
{
    public class CharacterFilmQuiz
    {
        public QuizId Id { get; }

        private readonly string characterName;

        public CharacterFilmQuiz(string characterName, Guid id = default(Guid))
        {
            if(id == default(Guid))
            {
                id = Guid.NewGuid();
            }
            Id = new QuizId(id);

            this.characterName = characterName;
        }

        public QuizCharacterFilmAnswerCollection GetAnswers()
        {
            return new QuizCharacterFilmAnswerCollection();
        }
    }
}
