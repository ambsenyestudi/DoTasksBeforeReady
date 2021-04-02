using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Quizing;
using Xunit;

namespace StarwarsTheme.Test.Quizing
{
    public class QuizCharacterFilmAnswerShould
    {
        
        [Fact]
        public void Given_Luck_when_quiz_should_say_old_saga()
        {
            var oldSagaIds = new EpisodeIdCollection(new int[] { 4, 5, 6 });
            var quiz = new CharacterFilmQuiz("Luck Skywalker");
            var answers = quiz.GetAnswers();
            Assert.Equal(oldSagaIds, answers.ToEpisodeIdCollection());
        }
    }
}
