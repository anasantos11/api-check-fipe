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
    public class ConsultaMarcaController : ControllerBase
    {
        /// <summary> Consulta das marcas dos veículo</summary>
        /// <remarks> Exemplo requisição:    GET /api/ConsultaMarca/Carros </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <returns>Lista contendo todas as marcas do tipo de veículo informado, com o código e nome da marca.</returns>
        [HttpGet("{tipoVeiculo}")]
        public IEnumerable<Marca> Get(TipoVeiculoFipe tipoVeiculo)
        {
            return Marca.Carregar(tipoVeiculo);
        }
    }
}
