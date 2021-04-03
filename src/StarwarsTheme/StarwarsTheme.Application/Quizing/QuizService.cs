using StarwarsTheme.Application.DTO;
using StarwarsTheme.Application.Films;
using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Films;
using StarwarsTheme.Domain.Quizing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Application.Quizing
{
    public class QuizService : IQuizService
    {
        private readonly IFilmRepository filmRepository;
        private readonly IQuizMappingService mappingService;

        public QuizService(IFilmRepository filmRepository, IQuizMappingService mappingService)
        {
            this.filmRepository = filmRepository;
            this.mappingService = mappingService;
        }
        public List<FilmYearQuestionDTO> GetQuestions()
        {
            var filmCollection = filmRepository.GetAll();
            var filmList = filmCollection.AsEnumerable().ToList();
            var resultList = new List<FilmYearQuestionDTO>();
            for (int i = 0; i < filmList.Count; i++)
            {
                var quizId = new QuizId(Guid.NewGuid());
                var film = filmList[i];
                var filmQuiz = Quiz.CreateFilmYearQuiz(quizId, film);
                resultList.Add(mappingService.ToQuestion(filmQuiz));
            }
            return resultList;
        }
    }
}
