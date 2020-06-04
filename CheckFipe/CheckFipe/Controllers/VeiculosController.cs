using System.Collections.Generic;
using CheckFipe.Application;
using CheckFipe.Application.CarregarVeiculosMaisProcurados;
using Microsoft.AspNetCore.Mvc;

namespace CheckFipe.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly ICarregarVeiculosMaisProcuradosUseCase CarregarVeiculosMaisProcuradosUseCase;

        public VeiculosController(ICarregarVeiculosMaisProcuradosUseCase carregarVeiculosMaisProcurados)
        {
            this.CarregarVeiculosMaisProcuradosUseCase = carregarVeiculosMaisProcurados;
        }
        /// <summary> Carrega os veículos mais procurados. Por default carregar os 3 mais procurados. </summary>
        /// <remarks> Exemplo requisição: GET /api/Veiculos?limit=3 </remarks>
        /// <returns> Lista contendo os veículos mais procurados.</returns>
        [HttpGet("{limit}", Name = "CarregarVeiculosMaisProcurados")]
        public IEnumerable<VeiculoOutput> CarregarVeiculosMaisProcurados(int limit = 3)
        {
            return this.CarregarVeiculosMaisProcuradosUseCase.Execute(limit);
        }
    }
}