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
        private readonly long CodigoMarca;
        private readonly long CodigoModelo;
        private readonly string CodigoAno;

        public VeiculoService(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno)
            : base(tipoVeiculo, TipoAcaoFipe.Veiculo, codigoMarca.ToString(), codigoModelo.ToString(), codigoAno)
        {
            this.CodigoMarca = codigoMarca;
            this.CodigoModelo = codigoModelo;
            this.CodigoAno = codigoAno;
        }

        public Veiculo Carregar()
        {
            IMapper mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<FipeVeiculoOutput, Veiculo>()
                    .ForMember(veiculo => veiculo.CodigoAnoModelo, opts => opts.MapFrom(veiculoFipe => this.CodigoAno))
                    .ForMember(veiculo => veiculo.Modelo,
                        opts => opts.MapFrom(veiculoFipe => new Domain.Entities.Modelo()
                        {
                            Id = this.CodigoModelo,
                            Nome = veiculoFipe.DescricaoModelo,
                            Marca = new Marca()
                            {
                                Id = this.CodigoMarca,
                                Nome = veiculoFipe.DescricaoMarca
                            }
                        })
                    ) ;
            }).CreateMapper();

            return mapperConfig.Map<Veiculo>(Carregar<FipeVeiculoOutput>());
        }
    }
}
