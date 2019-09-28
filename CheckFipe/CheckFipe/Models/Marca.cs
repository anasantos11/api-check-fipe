using Newtonsoft.Json;

namespace CheckFipe.Models
{
    public class Marca
    {
        [JsonProperty("id")]
        public long CodigoMarca { get; set; }

        [JsonProperty("fipe_name")]
        public string NomeMarca { get; set; }
    }
}
