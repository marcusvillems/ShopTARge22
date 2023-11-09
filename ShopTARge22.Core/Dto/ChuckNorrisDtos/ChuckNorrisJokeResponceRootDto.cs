using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Dto.ChuckNorrisDtos
{
    public class ChuckNorrisJokeResponceRootDto
    {

        [JsonPropertyName("categories")]
        public List<object> Categories { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("value")]
        public string Jokes { get; set; }

    }
}
