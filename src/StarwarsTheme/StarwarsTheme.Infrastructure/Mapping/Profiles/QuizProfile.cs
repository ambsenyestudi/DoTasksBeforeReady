using AutoMapper;
using StarwarsTheme.Application.DTO;
using StarwarsTheme.Domain.Quizing.FilmYears;

namespace StarwarsTheme.Infrastructure.Mapping.Profiles
{
    public class QuizProfile:Profile
    {
        public QuizProfile()
        {
            CreateMap<FilmYearQuiz, FilmYearQuestionDTO>()
                .ConvertUsing(fyq => new FilmYearQuestionDTO
                {
                    QuizId = fyq.Id.Value.ToString(),
                    Question = fyq.Heading
                });
        }
    }
}
