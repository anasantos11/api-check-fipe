using CheckFipe.Application.CarregarAnos;
using CheckFipe.Domain.Enumerators;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CheckFipe.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnosController : ControllerBase
    {
        private readonly ICarregarAnosUseCase CarregarAnosUseCase;
        public AnosController(ICarregarAnosUseCase carregarAnosUseCase)
        {
            this.CarregarAnosUseCase = carregarAnosUseCase;
        }

        /// <summary> Carrega os anos de um modelo de veículo da tabela Fipe</summary>
        /// <remarks> Exemplo requisição:    GET /api/Anos/Carros/21/4828 </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <param name="codigoMarca">Código da Marca</param>
        /// <param name="codigoModelo">Código do Modelo</param>
        /// <returns>Lista contendo todos os anos de um modelo de veículo, com o código e descrição do ano.</returns>
        [HttpGet("{tipoVeiculo}/{codigoMarca}/{codigoModelo}", Name = "CarregarAnos")]
        public IEnumerable<CarregarAnosOutput> CarregarAnos(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo)
        {
            return this.CarregarAnosUseCase.Execute(tipoVeiculo, codigoMarca, codigoModelo);
        }
    }
}
