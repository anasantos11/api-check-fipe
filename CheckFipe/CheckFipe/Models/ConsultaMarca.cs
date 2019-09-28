using CheckFipe.Enums;
using CheckFipe.Helpers;
using System.Collections.Generic;

namespace CheckFipe.Models
{
    public class ConsultaMarca
    {
        #region Construtores
        public ConsultaMarca(TipoVeiculoFipe tipoVeiculo)
        {
            this.TipoVeiculo = tipoVeiculo;
        }
        #endregion

        #region Propriedades e Atributos Internos
        private TipoVeiculoFipe TipoVeiculo { get; set; }
        private AcaoFipe AcaoFipe
        {
            get
            {
                return AcaoFipe.Marcas;
            }
        }
        private string _url;
        private string Url
        {
            get
            {
                if (this._url == null)
                {
                    _url = Fipe.CarregarUrl(this.TipoVeiculo, this.AcaoFipe);
                }
                return _url;
            }
        }

        #endregion

        #region Métodos Públicos
        public IEnumerable<RetornoFipe> Carregar()
        {
            return new HttpHelper(this.Url).DoRequestGet<IEnumerable<RetornoFipe>>();
        }
        #endregion
    }
}
