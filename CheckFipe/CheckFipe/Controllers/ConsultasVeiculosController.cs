using System.Collections.Generic;
using CheckFipe.Application.CarregarConsultasVeiculos;
using Microsoft.AspNetCore.Mvc;

namespace CheckFipe.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasVeiculosController : Controller
    {
        private readonly ICarregarConsultasVeiculosUseCase CarregarConsultarVeiculosUseCase;

        public ConsultasVeiculosController(ICarregarConsultasVeiculosUseCase carregarConsultarVeiculosUseCase)
        {
            this.CarregarConsultarVeiculosUseCase = carregarConsultarVeiculosUseCase;
        }

        /// <summary> Carrega as consultas realizadas de veículos a tabela Fipe.</summary>
        /// <remarks> Exemplo requisição: GET /api/ConsultasVeiculos </remarks>
        /// <returns> Lista contendo todas as consultas de veículos realizadas a tabela fipe.</returns>
        [HttpGet(Name = "CarregarConsultasVeiculos")]
        public IEnumerable<CarregarConsultasVeiculosOutput> CarregarConsultasVeiculos()
        {
            return this.CarregarConsultarVeiculosUseCase.Execute();
        }
    }
}