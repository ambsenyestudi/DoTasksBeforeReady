using Microsoft.AspNetCore.Mvc;
using StarwarsTheme.Application.DTO;
using StarwarsTheme.Application.Quizing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarwarsTheme.Controllers
{
    [Route("api/quiz/character")]
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
        [HttpPost("eye_color")]
        public bool Answer([FromBody] CharacterEyeColorAnswerDTO answer)
        {
            //todo filter for key not found exception
            return quizService.EvaluateEyeColorAnswer(answer);
            
        }
    }
}
