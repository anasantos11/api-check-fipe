using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckFipe.Enums;
using CheckFipe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckFipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaMarcaController : ControllerBase
    {
        [HttpGet("{tipoVeiculo}")]
        public IEnumerable<RetornoFipe> Get(TipoVeiculoFipe tipoVeiculo)
        {
           return new ConsultaMarca(tipoVeiculo).Carregar();
        }
    }
}
