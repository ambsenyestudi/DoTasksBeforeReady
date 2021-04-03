using Microsoft.AspNetCore.Mvc;
using StarwarsTheme.Application.DTO;
using StarwarsTheme.Application.Quizing;
using System.Collections.Generic;

namespace StarwarsTheme.Controllers
{
    [Route("api/quiz/film")]
    [ApiController]
    public class FilmYearController : ControllerBase
    {
        private readonly IQuizService quizService;

        public FilmYearController(IQuizService quizService)
        {
            this.quizService = quizService;
        }
        [HttpGet("year")]
        public IEnumerable<FilmYearQuestionDTO> List()
        {
            return quizService.GetFilmYearQuestions();
        }
        [HttpPost("year")]
        public bool Answer([FromBody] FilmYearAnswerDTO answer)
        {
            return quizService.EvaluateFilmYearAnswer(answer);
        }
    }
}
