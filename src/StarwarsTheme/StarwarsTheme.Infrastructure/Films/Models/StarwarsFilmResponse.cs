using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarwarsTheme.Infrastructure.Films.Models
{
    public class StarwarsFilmResponse
    {
        [JsonProperty("results")]
        public List<StarwarsFilm> Results { get; set; }
    }
}
