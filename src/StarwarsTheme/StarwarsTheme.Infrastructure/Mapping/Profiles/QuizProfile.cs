using AutoMapper;
using StarwarsTheme.Application.DTO;
using StarwarsTheme.Domain.Quizing.CharacterEyeColors;
using StarwarsTheme.Domain.Quizing.FilmYears;

namespace StarwarsTheme.Infrastructure.Mapping.Profiles
{
    public class QuizProfile:Profile
    {
        public QuizProfile()
        {
            CreateMap<FilmYearQuiz, QuizQuestionDTO>()
                .ConvertUsing(fyq => new QuizQuestionDTO
                {
                    QuizId = fyq.Id.Value.ToString(),
                    Question = fyq.Heading
                });
            CreateMap<CharacterEyeColorQuiz, QuizQuestionDTO>()
                .ConvertUsing(cec => new QuizQuestionDTO
                {
                    QuizId = cec.Id.Value.ToString(),
                    Question = cec.Heading
                });
        }
    }
}
