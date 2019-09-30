using System;
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
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FipeController : ControllerBase
    {
        /// <summary> Carrega as marcas dos veículo da tabela Fipe.</summary>
        /// <remarks> Exemplo requisição:    GET /api/Fipe/CarregarMarcas/Carros </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <returns>Lista contendo todas as marcas do tipo de veículo informado, com o código e nome da marca.</returns>
        [HttpGet("{tipoVeiculo}")]
        public IEnumerable<Marca> CarregarMarcas(TipoVeiculoFipe tipoVeiculo)
        {
            return Marca.Carregar(tipoVeiculo);
        }

        /// <summary> Carrega os modelos de uma marca de veículo da tabela Fipe</summary>
        /// <remarks> Exemplo requisição:    GET /api/Fipe/CarregarModelos/Carros/21 </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <param name="codigoMarca">Código da Marca</param>
        /// <returns>Lista contendo todos os modelos da marca, com o código e nome do modelo.</returns>
        [HttpGet("{tipoVeiculo}/{codigoMarca}")]
        public IEnumerable<Modelo> CarregarModelos(TipoVeiculoFipe tipoVeiculo, long codigoMarca)
        {
            return Modelo.Carregar(tipoVeiculo, codigoMarca);
        }

        /// <summary> Carrega os anos de um modelo de veículo da tabela Fipe</summary>
        /// <remarks> Exemplo requisição:    GET /api/Fipe/CarregarAnos/Carros/21/4828 </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <param name="codigoMarca">Código da Marca</param>
        /// <param name="codigoModelo">Código do Modelo</param>
        /// <returns>Lista contendo todos os anos de um modelo de veículo, com o código e descrição do ano.</returns>
        [HttpGet("{tipoVeiculo}/{codigoMarca}/{codigoModelo}")]
        public IEnumerable<Ano> CarregarAnos(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo)
        {
            return Ano.Carregar(tipoVeiculo, codigoMarca, codigoModelo);
        }

        /// <summary> Carrega os dados de um veículo da tabela Fipe</summary>
        /// <remarks> Exemplo requisição:    GET /api/Fipe/CarregarDadosVeiculo/Carros/21/4828/2013-1 </remarks>
        /// <param name="tipoVeiculo">Tipo do Veículo</param>
        /// <param name="codigoMarca">Código da Marca</param>
        /// <param name="codigoModelo">Código do Modelo</param>
        /// <param name="codigoAno">Código do Ano</param>
        /// <returns>Dados do veículo na tabela fipe.</returns>
        [HttpGet("{tipoVeiculo}/{codigoMarca}/{codigoModelo}/{codigoAno}")]
        public Veiculo CarregarDadosVeiculo(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno)
        {
            return Veiculo.Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
        }
    }
}
