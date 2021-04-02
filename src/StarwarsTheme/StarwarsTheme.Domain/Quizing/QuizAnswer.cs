using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsTheme.Domain.Quizing
{
    public record QuizAnswer
    {
        public QuizId Id { get; }
        public QuizAnswer(QuizId id) => (Id) = (id);
    }
}
