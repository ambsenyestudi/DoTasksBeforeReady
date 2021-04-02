using System;
using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Domain
{
    public class EpisodeIdCollection
    {
        private readonly IEnumerable<int> episodeIdCollection;
        private readonly int hasCode;
        public EpisodeIdCollection(IEnumerable<int> episodeIdCollection)
        {
            if(episodeIdCollection==null || !episodeIdCollection.Any())
            {
                throw new EmptyCollectionException($"{nameof(EpisodeIdCollection)} cannot be null or empty");
            }
            this.episodeIdCollection = episodeIdCollection;
            hasCode = episodeIdCollection.Select(x => GetHashCode()).Sum();
        }
        public override bool Equals(object obj)
        {
            var other = obj as EpisodeIdCollection;
            if (other is null)
            {
                return false;
            }
            return episodeIdCollection.SequenceEqual(other.episodeIdCollection);
        }
        public override int GetHashCode() => hasCode;
    }
}
