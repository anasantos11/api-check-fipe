using CheckFipe.Interfaces;
using Newtonsoft.Json;

namespace CheckFipe.Models
{
    public class Marca : IRetornoFipe
    {
        [JsonProperty("id")]
        public long Codigo { get; set; }

        [JsonProperty("fipe_name")]
        public string Nome { get; set; }
    }
}
