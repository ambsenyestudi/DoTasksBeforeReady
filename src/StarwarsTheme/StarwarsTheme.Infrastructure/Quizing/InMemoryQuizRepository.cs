﻿using StarwarsTheme.Application.Films;
using StarwarsTheme.Application.Quizing;
using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Films;
using StarwarsTheme.Domain.Quizing;
using StarwarsTheme.Domain.Quizing.FilmYears;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StarwarsTheme.Infrastructure.Quizing
{
    public class InMemoryQuizRepository : IQuizRepository
    {
        private readonly IFilmRepository filmRepository;
        private Dictionary<QuizId, FilmYearQuiz> filmYearQuizDictionary;
        public LastUpdated LastUpdated => LastUpdated.Never;

        public InMemoryQuizRepository(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
            Store(filmRepository.GetAll());
        }

        private void Store(FilmCollection filmCollection)
        {

            filmYearQuizDictionary = filmCollection.AsEnumerable()
                .Select(fl => Quiz.CreateFilmYearQuiz(new QuizId(Guid.NewGuid()), fl))
                .ToDictionary(k =>
                    k.Id,
                    v => v);
        }

        public IEnumerable<FilmYearQuiz> GetAllYearFilms() => 
            filmYearQuizDictionary.Values;

        public FilmYearQuiz GetBy(QuizId id) =>
            filmYearQuizDictionary[id];

        public async Task UpdateRepositoryAsync(CancellationToken cancellationToken) 
        {
            var filCollection = await Task.Factory.StartNew(() => filmRepository.GetAll());
            Store(filCollection);
        }
    }
}
