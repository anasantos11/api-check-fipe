using System.Collections.Generic;
using CheckFipe.Context;
using CheckFipe.Entities;
using CheckFipe.Enums;
using CheckFipe.Teste.Models;
using CheckFipe.UseCase;
using Microsoft.AspNetCore.Mvc;

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
    }
}