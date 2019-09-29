using CheckFipe.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFipe.Teste.Models
{
    public class VeiculoRetornoFipe : RetornoFipe
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

        [JsonProperty("key")]
        public string Chave { get; set; }
    }
}
