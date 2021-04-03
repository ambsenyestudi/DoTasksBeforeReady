using StarwarsTheme.Application.Characters;
using StarwarsTheme.Application.Films;
using StarwarsTheme.Application.Quizing;
using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Characters;
using StarwarsTheme.Domain.Films;
using StarwarsTheme.Domain.Quizing;
using StarwarsTheme.Domain.Quizing.CharacterEyeColors;
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
        private readonly ICharacterRepository characterRepository;
        private Dictionary<QuizId, FilmYearQuiz> filmYearQuizDictionary;
        private Dictionary<QuizId, CharacterEyeColorQuiz> characterEyeColorQuizDictionary;
        public LastUpdated LastUpdated => LastUpdated.Never;

        public InMemoryQuizRepository(IFilmRepository filmRepository, ICharacterRepository characterRepository)
        {
            this.filmRepository = filmRepository;
            this.characterRepository = characterRepository;
            Store(filmRepository.GetAll());
            Store(characterRepository.GetAll());
        }

        private void Store(FilmCollection filmCollection)
        {

            filmYearQuizDictionary = filmCollection.AsEnumerable()
                .Select(fl => Quiz.CreateFilmYearQuiz(new QuizId(Guid.NewGuid()), fl))
                .ToDictionary(k =>
                    k.Id,
                    v => v);            
        }
        private void Store(CharacterCollection characerCollection)
        {

            characterEyeColorQuizDictionary = characerCollection.AsEnumerable()
                .Select(ch => Quiz.CreatecharacterEyeColorQuizDictionary(new QuizId(Guid.NewGuid()), ch))
                .ToDictionary(k =>
                    k.Id,
                    v => v);

        }

        public IEnumerable<FilmYearQuiz> GetAllYearFilms() => 
            filmYearQuizDictionary.Values;

        public FilmYearQuiz GetFilmYearQuizBy(QuizId id)
        {
            if(!filmYearQuizDictionary.ContainsKey(id))
            {
                throw new QuizNotFoundException(id);
            }
            return filmYearQuizDictionary[id];
        }

        public CharacterEyeColorQuiz GetCharacterEyeColorQuizBy(QuizId id)
        {
            if (!characterEyeColorQuizDictionary.ContainsKey(id))
            {
                throw new QuizNotFoundException(id);
            }
            return characterEyeColorQuizDictionary[id];
        }

        public async Task UpdateRepositoryAsync(CancellationToken cancellationToken) 
        {
            var filCollection = await Task.Factory.StartNew(() => filmRepository.GetAll());
            Store(filCollection);
            Store(characterRepository.GetAll());
        }

        public IEnumerable<CharacterEyeColorQuiz> GetAllCharactersEyeColor() =>
            characterEyeColorQuizDictionary.Values;

        
    }
}
