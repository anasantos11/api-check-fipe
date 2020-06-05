using CheckFipe.Application;
using CheckFipe.Application.BuscarVeiculo;
using CheckFipe.Domain.Enumerators;
using Microsoft.AspNetCore.Mvc;

namespace CheckFipe.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BuscarVeiculoController : ControllerBase
    {
        private readonly IBuscarVeiculoUseCase BuscarVeiculoUseCase;
        public BuscarVeiculoController(IBuscarVeiculoUseCase buscarVeiculoUseCase)
        {
            this.BuscarVeiculoUseCase = buscarVeiculoUseCase;
        }

        /// <summary> Carrega os dados de um veículo da tabela Fipe</summary>
        /// <remarks> Exemplo requisição:    GET /api/BuscarVeiculo/Carros/21/4828/2013-1 </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <param name="codigoMarca">Código da Marca</param>
        /// <param name="codigoModelo">Código do Modelo</param>
        /// <param name="codigoAno">Código do Ano</param>
        /// <returns>Dados do veículo na tabela fipe.</returns>
        [HttpGet("{tipoVeiculo}/{codigoMarca}/{codigoModelo}/{codigoAno}", Name = "BuscarVeiculo")]
        public VeiculoOutput BuscarVeiculo(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno)
        {
            return this.BuscarVeiculoUseCase.Execute(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
        }
    }
}