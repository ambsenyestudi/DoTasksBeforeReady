using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Quizing;
using StarwarsTheme.Domain.Quizing.FilmYears;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static StarwarsTheme.Test.Quizing.QuizingConstans;

namespace StarwarsTheme.Test.Quizing.FilmYears
{
    public class FilmQuizShould
    {
        private readonly QuizId NEW_HOPE_YEAR_QUIZ_ID = new QuizId(new Guid("9652bac2-a122-46ec-a3b0-fb869ee77ca0"));
        private readonly QuizId WRONG_YEAR_QUIZ_ID = new QuizId(new Guid("6db1aa54-cd21-4485-8e59-60a099f50a7b"));
        [Fact]
        public void Reject_wrong_answer()
        {
            var sut = Quiz.CreateFilmYearQuiz(NEW_HOPE_YEAR_QUIZ_ID, NEW_HOPE_FILM);
            var wrongAnswer = new FilmYearAnswer(NEW_HOPE_YEAR_QUIZ_ID, 2002);
            Assert.False(sut.IsCorrectAnswer(wrongAnswer));
        }

        [Fact]
        public void Accept_right_answer()
        {
            var sut = Quiz.CreateFilmYearQuiz(NEW_HOPE_YEAR_QUIZ_ID, NEW_HOPE_FILM);
            var wrongAnswer = new FilmYearAnswer(NEW_HOPE_YEAR_QUIZ_ID, 1977);
            Assert.True(sut.IsCorrectAnswer(wrongAnswer));
        }

        [Theory]
        [InlineData(2002, false)]
        [InlineData(1977, true)]
        public void Evalate_answer_regardles_of_quiz_id(int year, bool isAccurate)
        {
            var sut = Quiz.CreateFilmYearQuiz(NEW_HOPE_YEAR_QUIZ_ID, NEW_HOPE_FILM);
            var wrongQuizIdAnswer = new FilmYearAnswer(WRONG_YEAR_QUIZ_ID, year);
            Assert.Equal(isAccurate, sut.IsCorrectAnswer(wrongQuizIdAnswer));
        }
    }
}
