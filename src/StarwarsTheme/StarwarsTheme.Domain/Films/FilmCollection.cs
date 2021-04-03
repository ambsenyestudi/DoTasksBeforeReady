using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Domain.Films
{
    public class FilmCollection
    {
        private readonly Dictionary<int, Film> filmDictionary = new Dictionary<int, Film>();
        public Film this[int id]
        {
            get => filmDictionary[id];
        }
        public FilmCollection(IEnumerable<Film> characters)
        {
            filmDictionary = characters.ToDictionary(k => k.Info.EpisodeId, v => v);
        }
        public IEnumerable<Film> AsEnumerable() =>
            filmDictionary.Values;
    }
}
