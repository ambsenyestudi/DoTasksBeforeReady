using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarwarsTheme.Infrastructure.Characters.Models
{
    public class StarwarsCharacter
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }
        [JsonProperty("films")]
        public List<string> Films { get; set; }
    }
}
