using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Domain.ServicesInterfaces;
using CheckFipe.Infraestructure.Proxy.DataTransferObjects;
using CheckFipe.Infraestructure.Proxy.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckFipe.Infraestructure.Proxy.Services
{
    public class MarcaService : FipeBaseService, IMarcaService
    {
        public IEnumerable<Marca> Carregar(TipoVeiculo tipoVeiculo)
        {
            return Carregar<IEnumerable<FipeBaseOutput>>(tipoVeiculo, TipoAcaoFipe.Marcas)
                .Select(retornoFipe => new Marca()
                {
                    Id = Convert.ToInt64(retornoFipe.Codigo),
                    Nome = retornoFipe.Nome
                })
                .OrderBy(retornoFipe => retornoFipe.Nome);
        }
    }
}
