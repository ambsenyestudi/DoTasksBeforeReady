using Newtonsoft.Json;

namespace StarwarsTheme.Infrastructure.Characters.Models
{
    public class StarwarsFilm
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("episode_id")]
        public int EpisodeId { get; set; }

        [JsonProperty("director")]
        public int Dirctor { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
    }
}
