using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Infraestructure.Proxy.Services;
using CheckFipe.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CheckFipe.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FipeController : ControllerBase
    {
        /// <summary> Carrega os anos de um modelo de veículo da tabela Fipe</summary>
        /// <remarks> Exemplo requisição:    GET /api/Fipe/CarregarAnos/Carros/21/4828 </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <param name="codigoMarca">Código da Marca</param>
        /// <param name="codigoModelo">Código do Modelo</param>
        /// <returns>Lista contendo todos os anos de um modelo de veículo, com o código e descrição do ano.</returns>
        [HttpGet("{tipoVeiculo}/{codigoMarca}/{codigoModelo}")]
        public IEnumerable<Ano> CarregarAnos(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo)
        {
            return new AnoService().Carregar(tipoVeiculo, codigoMarca.ToString(), codigoModelo.ToString());
        }
    }
}
