using Newtonsoft.Json;

namespace CheckFipe.Infraestructure.Proxy.DataTransferObjects
{
    public class FipeBaseOutput
    {
        [JsonProperty("id")]
        public string Codigo { get; set; }

        [JsonProperty("name")]
        public string Nome { get; set; }
    }
}
