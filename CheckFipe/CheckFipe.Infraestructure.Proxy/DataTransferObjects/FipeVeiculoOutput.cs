using Newtonsoft.Json;

namespace CheckFipe.Infraestructure.Proxy.DataTransferObjects
{
    public class FipeVeiculoOutput : FipeBaseOutput
    {
        [JsonProperty("referencia")]
        public string MesReferencia { get; set; }

        [JsonProperty("fipe_codigo")]
        public string CodigoFipe { get; set; }

        [JsonProperty("marca")]
        public string DescricaoMarca { get; set; }

        [JsonProperty("veiculo")]
        public string DescricaoModelo { get; set; }

        [JsonProperty("ano_modelo")]
        public string AnoModelo { get; set; }

        [JsonProperty("combustivel")]
        public string DescricaoCombustivel { get; set; }

        [JsonProperty("preco")]
        public string Preco { get; set; }
    }
}
