﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CheckFipe.Enums;
using CheckFipe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;

namespace CheckFipe.Controllers
{
    /// <summary> Consulta das marcas dos veículo</summary>
    /// <remarks> Exemplo requisição:    GET /api/ConsultaMarca/0 </remarks>
    /// <param name="tipoVeiculo">Tipo do Veículo</param>
    /// <returns>Lista contendo todas as marcas do tipo de veículo informado, com o código e nome da marca.</returns>
    [Produces("application/json")]
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