using System.Collections.Generic;
using CheckFipe.Application.CarregarModelos;
using CheckFipe.Domain.Enumerators;
using Microsoft.AspNetCore.Mvc;

namespace CheckFipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly ICarregarModelosUseCase CarregarModelosUseCase;
        public ModelosController(ICarregarModelosUseCase carregarModelosUseCase)
        {
            this.CarregarModelosUseCase = carregarModelosUseCase;
        }

        /// <summary> Carrega os modelos de uma marca de veículo da tabela Fipe</summary>
        /// <remarks> Exemplo requisição:    GET /api/Modelos/Carros/21 </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <param name="codigoMarca">Código da Marca</param>
        /// <returns>Lista contendo todos os modelos da marca, com o código e nome do modelo.</returns>
        [HttpGet("{tipoVeiculo}/{codigoMarca}")]
        public IEnumerable<CarregarModelosOutput> CarregarModelos(TipoVeiculo tipoVeiculo, long codigoMarca)
        {
            return this.CarregarModelosUseCase.Execute(tipoVeiculo, codigoMarca);
        }
    }
}