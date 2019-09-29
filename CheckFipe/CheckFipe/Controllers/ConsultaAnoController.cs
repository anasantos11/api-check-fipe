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
    public class ConsultaAnoController : ControllerBase
    {
        /// <summary> Consulta os anos de um modelo de veículo</summary>
        /// <remarks> Exemplo requisição:    GET /api/ConsultaAno/Carros/21/4828 </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <param name="codigoMarca">Código da Marca</param>
        /// <param name="codigoModelo">Código do Modelo</param>
        /// <returns>Lista contendo todos os anos de um modelo de veículo, com o código e descrição do ano.</returns>
        [HttpGet("{tipoVeiculo}/{codigoMarca}/{codigoModelo}")]
        public IEnumerable<Ano> Get(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo)
        {
            return Ano.Carregar(tipoVeiculo, codigoMarca, codigoModelo);
        }
    }
}
