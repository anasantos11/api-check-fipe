using CheckFipe.Domain.Enumerators;
using CheckFipe.Infraestructure.Proxy.Enumerators;
using CheckFipe.Infraestructure.Proxy.Helpers;
using System.Linq;

namespace CheckFipe.Infraestructure.Proxy.Services
{
    public class FipeBaseService
    {
        private const string UrlApiFipe = "http://fipeapi.appspot.com/api/1";

        private string CarregarUrl(TipoVeiculo tipoVeiculo, TipoAcaoFipe acaoFipe, params string[] parametros)
        {
            string url = $"{UrlApiFipe}/{tipoVeiculo.ToString().ToLower()}/{acaoFipe.ToString().ToLower()}";
            if (parametros.Count() > 0)
            {
                url += "/" + string.Join("/", parametros);
            }
            return url + ".json";
        }

        public T Carregar<T>(TipoVeiculo tipoVeiculo, TipoAcaoFipe acaoFipe, params string[] parametros)
        {
            return new HttpHelper(CarregarUrl(tipoVeiculo, acaoFipe, parametros)).DoRequestGet<T>();
        }
    }
}
