using Newtonsoft.Json;

namespace CheckFipe.Models
{
    public class RetornoFipe
    {
        [JsonProperty("id")]
        public string Codigo { get; set; }

        [JsonProperty("name")]
        public string Nome { get; set; }
    }
}
