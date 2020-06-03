using CheckFipe.Context;
using CheckFipe.Domain.Entities;
using CheckFipe.UseCase;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CheckFipe.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CheckFipeController : ControllerBase
    {
        private readonly CheckFipeContext Context;

        public CheckFipeController(CheckFipeContext context)
        {
            this.Context = context;
        }

        /// <summary> Carrega as consultas realizadas de veículos a tabela Fipe.</summary>
        /// <remarks> Exemplo requisição: GET /api/CheckFipe/CarregarVeiculosConsultados </remarks>
        /// <returns> Lista contendo todas as consultas de veículos realizadas a tabela fipe.</returns>
        [HttpGet]
        public IEnumerable<ConsultaVeiculo> CarregarVeiculosConsultados()
        {
            return new CarregarConsultasVeiculosRealizadas(this.Context).Carregar();
        }

        /// <summary> Carrega os 3 veículos mais procurados.</summary>
        /// <remarks> Exemplo requisição: GET /api/CheckFipe/CarregarVeiculosMaisProcurados </remarks>
        /// <returns> Lista contendo os três veículos mais procurados.</returns>
        [HttpGet]
        public IEnumerable<Veiculo> CarregarVeiculosMaisProcurados()
        {
            return new CarregarVeiculosMaisProcurados(this.Context).Carregar();
        }
    }
}