﻿using StarwarsTheme.Application.DTO;
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
        public List<FilmYearQuestionDTO> GetFilmYearQuestions()
        {
            var quizCollection = repository.GetAllYearFilms();
            var quizList = quizCollection.AsEnumerable().ToList();
            var resultList = new List<FilmYearQuestionDTO>();
            for (int i = 0; i < quizList.Count; i++)
            {
                var quiz = quizList[i];
                resultList.Add(mappingService.ToQuestion(quiz));
            }
            return resultList;
        }
    }
}
