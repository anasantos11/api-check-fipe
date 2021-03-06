﻿using CheckFipe.Domain.Exceptions;
using CheckFipe.Infraestructure.Proxy.Helpers;
using NUnit.Framework;

namespace CheckFipe.Teste
{
    public class HttpHerlperTest
    {
        [Test]
        public void ValidarRequisicaoGetValida()
        {
            var resposta = new HttpHelper("http://fipeapi.appspot.com/api/1/carros/marcas.json").DoRequestGet<dynamic>();
            Assert.IsNotNull(resposta);
        }

        [Test]
        public void ValidarRequisicaoGetInvalida()
        {
            Assert.Throws<UnexpectedServiceResponseException>(() => new HttpHelper("urlqualquer").DoRequestGet<dynamic>());
        }
    }
}
