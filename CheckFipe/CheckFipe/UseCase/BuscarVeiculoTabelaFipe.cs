using CheckFipe.Enums;
using CheckFipe.Infrastructure.Data.Interfaces;
using CheckFipe.Models;
using CheckFipe.Infrastructure.Data.Repositories;
using CheckFipe.Domain.Entities;
using AutoMapper;
using System;

namespace CheckFipe.UseCase
{
    public class BuscarVeiculoTabelaFipe
    {
        public BuscarVeiculoTabelaFipe(ICheckFipeContext context)
        {
            this.Context = context;
        }

        private ICheckFipeContext Context { get; }

        public VeiculoRetornoFipe Carregar(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno)
        {
            VeiculoRetornoFipe retornoFipe = new ConsultaFipe(tipoVeiculo, AcaoFipe.Veiculo, codigoMarca.ToString(), codigoModelo.ToString(), codigoAno)
                .Carregar<VeiculoRetornoFipe>();

            var veiculoRepository = new VeiculoRepository(this.Context);
            Veiculo veiculo = veiculoRepository.Carregar(codigoModelo, retornoFipe.CodigoFipe, codigoAno);

            if (veiculo == null)
            {

                IMapper mapperConfig = new MapperConfiguration(config =>
                {
                    config.CreateMap<VeiculoRetornoFipe, Veiculo>()
                        .ForMember(veiculo => veiculo.CodigoAnoModelo, opts => opts.MapFrom(veiculoFipe => codigoAno))
                        .ForMember(veiculo => veiculo.Modelo,
                            opts => opts.MapFrom(veiculoFipe => new Domain.Entities.Modelo()
                            {
                                Id = codigoModelo,
                                Nome = veiculoFipe.DescricaoModelo,
                                Marca = new Domain.Entities.Marca()
                                {
                                    Id = codigoMarca,
                                    Nome = veiculoFipe.DescricaoMarca
                                }
                            })
                        );
                }).CreateMapper();

                veiculo = mapperConfig.Map<VeiculoRetornoFipe, Veiculo>(retornoFipe);

                veiculo.AddConsultaVeiculo();
                veiculoRepository.Cadastrar(veiculo);
            }
            else
            {
                veiculo.AddConsultaVeiculo();
                veiculoRepository.Atualizar(veiculo);
            }


            return retornoFipe;
        }
    }
}
