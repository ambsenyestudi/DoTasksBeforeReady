namespace StarwarsTheme.Domain.Films
{
    public class Film
    {
        public FilmId Id { get; }
        public FilmInfo Info { get; }
        public Film(FilmId id, FilmInfo info) => (Id, Info) = (id, info);
    }
}
