using Newtonsoft.Json;

namespace CheckFipe.Models
{
    public class RetornoFipe
    {
        [JsonProperty("id")]
        public long Codigo { get; set; }

        [JsonProperty("name")]
        public string Nome { get; set; }
    }
}
