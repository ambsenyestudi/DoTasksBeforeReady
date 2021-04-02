using System;

namespace StarwarsTheme.Domain.Characters
{
    public record CharacterId
    {
        public Guid Value { get; }
        public CharacterId(Guid id) => (Value) = (id);
    }
}
