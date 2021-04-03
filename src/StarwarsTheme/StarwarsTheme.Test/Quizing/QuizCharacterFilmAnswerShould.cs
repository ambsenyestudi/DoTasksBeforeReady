using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Characters;
using StarwarsTheme.Domain.Films;
using StarwarsTheme.Domain.Quizing;
using System;
using System.Collections.Generic;
using Xunit;

namespace StarwarsTheme.Test.Quizing
{
    public class QuizCharacterFilmAnswerShould
    {
        //6db1aa54-cd21-4485-8e59-60a099f50a7b}
        //9652bac2-a122-46ec-a3b0-fb869ee77ca0 
        private readonly CharacterId LUCK_ID = new CharacterId(new Guid("12d7a74f-13b7-4978-9b27-6cf222d5cb26"));
        private readonly Character LUCK;
        private readonly QuizId LUCK_QUIZ_ID = new QuizId(new Guid("9df03625-16ad-40cb-8780-a976d6a90945"));
        public QuizCharacterFilmAnswerShould()
        {
            LUCK = new Character(LUCK_ID, new CharacterInfo("Luck Skywalker", "blue"));
        }
        [Fact]
        public void Given_Luck_when_quiz_should_say_old_saga()
        {
            var oldSagaIds = new EpisodeIdCollection(new int[] { 4, 5, 6 });

            var quiz = Quiz.CreateCharacterFilmQuiz(LUCK, QuizingConstans.OLD_SAGA_FILM_LIST, LUCK_QUIZ_ID);
            var answers = quiz.GetAnswers();
            var episodeIdCollection = answers.ToEpisodeIdCollection();
            Assert.Equal(oldSagaIds, episodeIdCollection);
        }
        
        [Fact]
        public void Throw_when_empty_list()
        {
            var emptyFilmList = default(IEnumerable<Film>);
            Assert.Throws<ArgumentException>(()=> Quiz.CreateCharacterFilmQuiz(LUCK, emptyFilmList, LUCK_QUIZ_ID));
            
        }
        
        [Fact]
        public void Throw_when_no_character()
        {
            var noNameCharacter = default(Character);
            Assert.Throws<ArgumentException>(() => Quiz.CreateCharacterFilmQuiz(noNameCharacter, QuizingConstans.OLD_SAGA_FILM_LIST, LUCK_QUIZ_ID));

        }
        

    }
}
