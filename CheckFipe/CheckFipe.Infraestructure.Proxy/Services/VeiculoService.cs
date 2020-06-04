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
        public VeiculoService(TipoVeiculo tipoVeiculo, string codigoMarca, string codigoModelo, string codigoAno)
            : base(tipoVeiculo, TipoAcaoFipe.Veiculo, codigoMarca, codigoModelo, codigoAno)
        {

        }

        public Veiculo Carregar()
        {
            IMapper mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<FipeVeiculoOutput, Veiculo>()
                    .ForMember(veiculo => veiculo.CodigoAnoModelo, opts => opts.MapFrom(veiculoFipe => veiculoFipe.AnoModelo))
                    .ForMember(veiculo => veiculo.Modelo,
                        opts => opts.MapFrom(veiculoFipe => new Domain.Entities.Modelo()
                        {
                            Nome = veiculoFipe.DescricaoModelo,
                            Marca = new Marca()
                            {
                                Nome = veiculoFipe.DescricaoMarca
                            }
                        })
                    );
            }).CreateMapper();

            return mapperConfig.Map<Veiculo>(Carregar<FipeVeiculoOutput>());
        }
    }
}
