using CheckFipe.Domain.Enumerators;
using CheckFipe.Infraestructure.Proxy.Enumerators;
using CheckFipe.Infraestructure.Proxy.Helpers;
using System.Linq;
using System.Text;

namespace CheckFipe.Infraestructure.Proxy.Services
{
    public class FipeBaseService
    {
        private const string UrlApiFipe = "http://fipeapi.appspot.com/api/1";
        private TipoVeiculo TipoVeiculo { get; set; }
        private TipoAcaoFipe AcaoFipe { get; set; }
        public string[] Parametros { get; set; }
        private string _url;
        private string Url
        {
            get
            {
                if (this._url == null)
                {
                    _url = CarregarUrl();
                }
                return _url;
            }
        }

        public FipeBaseService(TipoVeiculo tipoVeiculo, TipoAcaoFipe acaoFipe, params string[] parametros)
        {
            this.TipoVeiculo = tipoVeiculo;
            this.AcaoFipe = acaoFipe;
            this.Parametros = parametros;
        }

        private string CarregarUrl()
        {
            string url = $"{UrlApiFipe}/{this.TipoVeiculo.ToString().ToLower()}/{this.AcaoFipe.ToString().ToLower()}";
            if (this.Parametros.Count() > 0)
            {
                url += "/" + string.Join("/", this.Parametros);
            }
            return url + ".json";
        }

        public T Carregar<T>()
        {
            return new HttpHelper(this.Url).DoRequestGet<T>();
        }
    }
}
