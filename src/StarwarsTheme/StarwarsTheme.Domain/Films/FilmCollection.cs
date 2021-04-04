using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Domain.Films
{
    public class FilmCollection : IEnumerable<Film>
    {
        private readonly Dictionary<FilmId, Film> filmDictionary = new Dictionary<FilmId, Film>();
        public Film this[FilmId id]
        {
            get => filmDictionary[id];
        }
        public FilmCollection(IEnumerable<Film> characters)
        {
            filmDictionary = characters.ToDictionary(k => k.Id, v => v);
        }

        public IEnumerator<Film> GetEnumerator() => filmDictionary.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    
    }
}
