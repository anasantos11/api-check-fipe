using CheckFipe.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFipe.Teste
{
    public class MarcaTest
    {
        [Test]
        public void ValidarSerializacaoObjeto()
        {
            var retornoFipe = new Marca()
            {
                Codigo = 21,
                Nome = "Fiat"
            };

            string retornoFipeJson = JsonConvert.SerializeObject(retornoFipe);
            JObject retornoFipeJbject = JObject.Parse(retornoFipeJson);

            Assert.AreEqual(21, retornoFipeJbject["id"].Value<long>());
            Assert.AreEqual("Fiat", retornoFipeJbject["fipe_name"].Value<string>());
        }
    }
}
