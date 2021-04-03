using System;

namespace StarwarsTheme.Domain.Quizing
{
    public class QuizNotFoundException: Exception
    {
        public const string errorTemplate = "Quiz with id {0} not found";
        public QuizNotFoundException(QuizId id):base (string.Format(errorTemplate, id.Value.ToString()))
        {

        }
    }
}
