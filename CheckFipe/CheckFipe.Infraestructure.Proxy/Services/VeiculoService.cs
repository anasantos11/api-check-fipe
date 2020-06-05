using AutoMapper;
using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Domain.ServicesInterfaces;
using CheckFipe.Infraestructure.Proxy.DataTransferObjects;
using CheckFipe.Infraestructure.Proxy.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFipe.Infraestructure.Proxy.Services
{
    public class VeiculoService : FipeBaseService, IVeiculoService
    {
        public Veiculo Carregar(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno)
        {
            IMapper mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<FipeVeiculoOutput, Veiculo>()
                    .ForMember(veiculo => veiculo.CodigoAnoModelo, opts => opts.MapFrom(veiculoFipe => codigoAno))
                    .ForMember(veiculo => veiculo.Modelo,
                        opts => opts.MapFrom(veiculoFipe => new Domain.Entities.Modelo()
                        {
                            Id = codigoModelo,
                            Nome = veiculoFipe.DescricaoModelo,
                            Marca = new Marca()
                            {
                                Id = codigoMarca,
                                Nome = veiculoFipe.DescricaoMarca
                            }
                        })
                    );
            }).CreateMapper();

            return mapperConfig.Map<Veiculo>(Carregar<FipeVeiculoOutput>(tipoVeiculo, TipoAcaoFipe.Veiculo, codigoMarca.ToString(), codigoModelo.ToString(), codigoAno));
        }
    }
}
