using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CheckFipe.Enums;
using CheckFipe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;

namespace CheckFipe.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarregarDadosVeiculoFipeController : ControllerBase
    {
        /// <summary> Carrega os dados de um veículo da tabela Fipe</summary>
        /// <remarks> Exemplo requisição:    GET /api/CarregarDadosVeiculoFipe/Carros/21/4828/2013-1 </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <param name="codigoMarca">Código da Marca</param>
        /// <param name="codigoModelo">Código do Modelo</param>
        /// <param name="codigoAno">Código do Ano</param>
        /// <returns>Dados do veículo na tabela fipe.</returns>
        [HttpGet("{tipoVeiculo}/{codigoMarca}/{codigoModelo}")]
        public Veiculo Get(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno)
        {
            return Veiculo.Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
        }
    }
}
