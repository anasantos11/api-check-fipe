using CheckFipe.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckFipe.Models
{
    public class Fipe
    {
        #region Constantes Internas
        private const string URL_API_FIPE = "http://fipeapi.appspot.com/api/1";
        #endregion

        #region Métodos Públics
        public static string CarregarUrl(TipoVeiculoFipe tipoVeiculo, AcaoFipe acao, params string[] parametros)
        {
            string url = $"{URL_API_FIPE}/{tipoVeiculo.ToString().ToLower()}/{acao.ToString().ToLower()}";
            if (parametros.Count() > 0)
            {
                url += "/" + string.Join("/", parametros);
            }
            return url + ".json";
        } 
        #endregion
    }
}
