using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Domain.ServicesInterfaces;
using CheckFipe.Infraestructure.Proxy.DataTransferObjects;
using CheckFipe.Infraestructure.Proxy.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Infraestructure.Proxy.Services
{
    public class ModeloService : FipeBaseService, IModeloService
    {
        public IEnumerable<Modelo> Carregar(TipoVeiculo tipoVeiculo, string codigoMarca)
        {
            return Carregar<IEnumerable<FipeBaseOutput>>(tipoVeiculo, TipoAcaoFipe.Veiculos, codigoMarca)
                .Select(retornoFipe => new Modelo()
                {
                    Id = Convert.ToInt64(retornoFipe.Codigo),
                    Nome = retornoFipe.Nome
                })
                .OrderBy(retornoFipe => retornoFipe.Nome);
        }
    }
}
