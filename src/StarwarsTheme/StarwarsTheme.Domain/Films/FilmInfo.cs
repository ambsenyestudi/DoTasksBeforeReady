namespace StarwarsTheme.Domain.Films
{
    public record FilmInfo
    {

        public string Title { get; }

        public int EpisodeId { get; }

        public string Director { get; }

        public ReleaseDate ReleaseDate { get; }

        public FilmInfo(string title, string director, int episodeId, ReleaseDate releaseDate) => (Title, EpisodeId, Director, ReleaseDate) = (title, episodeId, director, releaseDate);


    }
}
