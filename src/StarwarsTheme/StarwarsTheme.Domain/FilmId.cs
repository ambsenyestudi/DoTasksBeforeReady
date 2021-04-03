using System;

namespace StarwarsTheme.Domain
{
    public record FilmId
    {
        public Guid Value { get; }
        public static FilmId Empty { get; } = new FilmId(Guid.Empty);

        public FilmId(Guid id) => (Value) = (id);
    }
}
