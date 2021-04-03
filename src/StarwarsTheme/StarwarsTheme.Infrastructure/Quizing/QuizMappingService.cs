using AutoMapper;
using StarwarsTheme.Application.DTO;
using StarwarsTheme.Application.Quizing;
using StarwarsTheme.Domain.Quizing.CharacterEyeColors;
using StarwarsTheme.Domain.Quizing.FilmYears;

namespace StarwarsTheme.Infrastructure.Quizing
{
    public class QuizMappingService : IQuizMappingService
    {
        private readonly IMapper mapper;

        public QuizMappingService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public QuizQuestionDTO ToCharacterEyeColorQuestion(CharacterEyeColorQuiz quiz) =>
            mapper.Map<QuizQuestionDTO>(quiz);

        public QuizQuestionDTO ToFilmYearQuestion(FilmYearQuiz quiz) =>
            mapper.Map<QuizQuestionDTO>(quiz);
    }
}
