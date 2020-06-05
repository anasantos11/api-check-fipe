using CheckFipe.Infraestructure.Proxy.DataTransferObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace CheckFipe.Teste
{
    public class FipeBaseOutputTest
    {
        [Test]
        public void ValidarSerializacaoObjeto()
        {
            var retornoFipe = new FipeBaseOutput()
            {
                Codigo = "21",
                Nome = "Fiat"
            };

            string retornoFipeJson = JsonConvert.SerializeObject(retornoFipe);
            JObject retornoFipeJbject = JObject.Parse(retornoFipeJson);

            Assert.AreEqual("21", retornoFipeJbject["id"]?.Value<string>());
            Assert.AreEqual("Fiat", retornoFipeJbject["name"]?.Value<string>());
        }

        [Test]
        public void ValidarDeserializacaoObjetoRetornoFipe()
        {
            string jsonRetornoFipe = @"{""id"": 21, ""name"": ""Fiat""}";

            FipeBaseOutput retorno = JsonConvert.DeserializeObject<FipeBaseOutput>(jsonRetornoFipe);
            Assert.IsNotNull(retorno);
            Assert.AreEqual("21", retorno.Codigo);
            Assert.AreEqual("Fiat", retorno.Nome);
        }
    }
}
