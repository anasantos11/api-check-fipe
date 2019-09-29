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
    /// <summary> Consulta os modelos de uma marca de veículo</summary>
    /// <remarks> Exemplo requisição:    GET /api/ConsultaModelo/Carros/21 </remarks>
    /// <param name="tipoVeiculo">Tipo do Veículo</param>
    /// <param name="codigoMarca">Código da Marca</param>
    /// <returns>Lista contendo todos os modelos da marca, com o código e nome do modelo.</returns>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaModeloController : ControllerBase
    {
        [HttpGet("{tipoVeiculo}/{codigoMarca}")]
        public IEnumerable<Marca> Get(TipoVeiculoFipe tipoVeiculo, int codigoMarca)
        {
            return new ConsultaFipe(tipoVeiculo, AcaoFipe.Veiculos, codigoMarca.ToString()).Carregar();
        }
    }
}
