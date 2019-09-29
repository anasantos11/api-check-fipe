using CheckFipe.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFipe.Teste
{
    public class RetornoTest
    {
        [Test]
        public void ValidarSerializacaoObjeto()
        {
            var retornoFipe = new RetornoFipe()
            {
                Codigo = 21,
                Nome = "Fiat"
            };

            string retornoFipeJson = JsonConvert.SerializeObject(retornoFipe);
            JObject retornoFipeJbject = JObject.Parse(retornoFipeJson);

            Assert.AreEqual(21, retornoFipeJbject["id"]?.Value<long>());
            Assert.AreEqual("Fiat", retornoFipeJbject["name"]?.Value<string>());
        }

        [Test]
        public void ValidarDeserializacaoObjetoRetornoFipe()
        {
            string jsonRetornoFipe = @"{""id"": 21, ""name"": ""Fiat""}";

            RetornoFipe retorno = JsonConvert.DeserializeObject<RetornoFipe>(jsonRetornoFipe);
            Assert.IsNotNull(retorno);
            Assert.AreEqual(21, retorno.Codigo);
            Assert.AreEqual("Fiat", retorno.Nome);
        }
    }
}
