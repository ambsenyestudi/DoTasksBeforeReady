using StarwarsTheme.Application.DTO;
using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Quizing.CharacterEyeColors;
using StarwarsTheme.Domain.Quizing.FilmYears;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Application.Quizing
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository repository;
        private readonly IQuizMappingService mappingService;

        public QuizService(IQuizRepository repository, IQuizMappingService mappingService)
        {
            this.repository = repository;
            this.mappingService = mappingService;
        }

        public List<QuizQuestionDTO> GetFilmYearQuestions()
        {
            var quizCollection = repository.GetAllYearFilms();
            var quizList = quizCollection.ToList();
            var resultList = new List<QuizQuestionDTO>();
            for (int i = 0; i < quizList.Count; i++)
            {
                var quiz = quizList[i];
                resultList.Add(mappingService.ToFilmYearQuestion(quiz));
            }
            return resultList;
        }

        public bool EvaluateFilmYearAnswer(FilmYearAnswerDTO rawAnswer)
        {
            var quizId = new QuizId(new Guid(rawAnswer.QuizId));
            var filmYearQuiz = repository.GetFilmYearQuizBy(quizId);
            var answer = new FilmYearAnswer(quizId, rawAnswer.Year);
            return filmYearQuiz.IsCorrectAnswer(answer);
        }

        public IEnumerable<QuizQuestionDTO> GetCharacterEyeColorQuestions()
        {
            var quizCollection = repository.GetAllCharactersEyeColor();
            var quizList = quizCollection.ToList();
            var resultList = new List<QuizQuestionDTO>();
            for (int i = 0; i < quizList.Count; i++)
            {
                var quiz = quizList[i];
                resultList.Add(mappingService.ToCharacterEyeColorQuestion(quiz));
            }
            return resultList;
        }

        public bool EvaluateEyeColorAnswer(CharacterEyeColorAnswerDTO rawAnswer)
        {
            var quizId = new QuizId(new Guid(rawAnswer.QuizId));
            var filmYearQuiz = repository.GetCharacterEyeColorQuizBy(quizId);
            var answer = new CharacterEyeColorAnswer(quizId, rawAnswer.EyeColor);
            return filmYearQuiz.IsCorrectAnswer(answer);
        }
    }
}
