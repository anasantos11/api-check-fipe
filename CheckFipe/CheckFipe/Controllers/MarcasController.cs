using CheckFipe.Application.CarregarMarcas;
using CheckFipe.Domain.Enumerators;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CheckFipe.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly ICarregarMarcasUseCase CarregarMarcaUseCase;
        public MarcasController(ICarregarMarcasUseCase carregarMarcaUseCase)
        {
            this.CarregarMarcaUseCase = carregarMarcaUseCase;
        }

        /// <summary> Carrega as marcas dos veículo da tabela Fipe.</summary>
        /// <remarks> Exemplo requisição:    GET /api/Marcas/Carros </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <returns>Lista contendo todas as marcas do tipo de veículo informado, com o código e nome da marca.</returns>
        [HttpGet("{tipoVeiculo}", Name = "CarregarMarcas")]
        public IEnumerable<CarregarMarcasOutput> CarregarMarcas(TipoVeiculo tipoVeiculo)
        {
            return this.CarregarMarcaUseCase.Execute(tipoVeiculo);
        }
    }
}