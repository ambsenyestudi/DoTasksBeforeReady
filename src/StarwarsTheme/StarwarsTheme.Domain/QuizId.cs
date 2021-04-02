using System;

namespace StarwarsTheme.Domain
{
    public record QuizId
    {
        public Guid Value { get; }
        public QuizId(Guid id) => (Value) = (id);
    }
}
