using CheckFipe.Domain.Enumerators;
using CheckFipe.Enums;
using CheckFipe.Helpers;
using System.Linq;

namespace CheckFipe.Models
{
    public class ConsultaFipe
    {
        #region Constantes Internas
        private const string URL_API_FIPE = "http://fipeapi.appspot.com/api/1";
        #endregion

        #region Construtores
        public ConsultaFipe(TipoVeiculo tipoVeiculo, AcaoFipe acaoFipe, params string[] parametros)
        {
            this.TipoVeiculo = tipoVeiculo;
            this.AcaoFipe = acaoFipe;
            this.Parametros = parametros;
        }
        #endregion

        #region Propriedades e Atributos Internos
        private TipoVeiculo TipoVeiculo { get; set; }
        private AcaoFipe AcaoFipe { get; set; }
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

        #endregion

        #region Métodos Públicos
        public T Carregar<T>()
        {
            return new HttpHelper(this.Url).DoRequestGet<T>();
        }
        #endregion

        #region Métodos Internos
        private string CarregarUrl()
        {
            string url = $"{URL_API_FIPE}/{this.TipoVeiculo.ToString().ToLower()}/{this.AcaoFipe.ToString().ToLower()}";
            if (this.Parametros.Count() > 0)
            {
                url += "/" + string.Join("/", this.Parametros);
            }
            return url + ".json";
        }
        #endregion
    }
}
