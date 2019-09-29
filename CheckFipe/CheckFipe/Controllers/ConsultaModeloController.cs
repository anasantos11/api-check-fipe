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
    public class ConsultaModeloController : ControllerBase
    {
        /// <summary> Consulta os modelos de uma marca de veículo</summary>
        /// <remarks> Exemplo requisição:    GET /api/ConsultaModelo/Carros/21 </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <param name="codigoMarca">Código da Marca</param>
        /// <returns>Lista contendo todos os modelos da marca, com o código e nome do modelo.</returns>
        [HttpGet("{tipoVeiculo}/{codigoMarca}")]
        public IEnumerable<Modelo> Get(TipoVeiculoFipe tipoVeiculo, long codigoMarca)
        {
            return Modelo.Carregar(tipoVeiculo, codigoMarca);
        }
    }
}
