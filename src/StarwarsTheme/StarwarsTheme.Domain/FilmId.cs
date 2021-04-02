using System;

namespace StarwarsTheme.Domain
{
    public record FilmId
    {
        public Guid Value { get; }
        public FilmId(Guid id) => (Value) = (id);
    }
}
