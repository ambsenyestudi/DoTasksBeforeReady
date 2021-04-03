using Microsoft.AspNetCore.Mvc;
using StarwarsTheme.Application.DTO;
using StarwarsTheme.Application.Quizing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarwarsTheme.Controllers
{
    [Route("api/quiz/characte")]
    [ApiController]
    public class CharacterEyeColorController : ControllerBase
    {
        private readonly IQuizService quizService;
        public CharacterEyeColorController(IQuizService quizService)
        {
            this.quizService = quizService;
        }
        [HttpGet("eye_color")]
        public IEnumerable<QuizQuestionDTO> List()
        {
            return quizService.GetCharacterEyeColorQuestions();
        }
    }
}
