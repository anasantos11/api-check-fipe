using AutoMapper;
using CheckFipe.Application;
using CheckFipe.Application.CarregarAnos;
using CheckFipe.Application.CarregarConsultasVeiculos;
using CheckFipe.Application.CarregarMarcas;
using CheckFipe.Application.CarregarModelos;
using CheckFipe.Domain.Entities;

namespace CheckFipe
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ConsultaVeiculo, CarregarConsultasVeiculosOutput>();
            CreateMap<Veiculo, VeiculoOutput>()
                        .ForMember(veiculoOutput => veiculoOutput.DescricaoMarca, opts => opts.MapFrom(veiculo => veiculo.Modelo.Marca.Nome))
                        .ForMember(veiculoOutput => veiculoOutput.DescricaoModelo, opts => opts.MapFrom(veiculo => veiculo.Modelo.Nome));
            CreateMap<Marca, CarregarMarcasOutput>()
                 .ForMember(marcaOutput => marcaOutput.Codigo, opts => opts.MapFrom(marca => marca.Id));
            CreateMap<Modelo, CarregarModelosOutput>()
                 .ForMember(modeloOutput => modeloOutput.Codigo, opts => opts.MapFrom(modelo => modelo.Id));
            CreateMap<Ano, CarregarAnosOutput>()
                .ForMember(anoOutput => anoOutput.Codigo, opts => opts.MapFrom(ano => ano.CodigoAnoModelo))
                .ForMember(anoOutput => anoOutput.Nome, opts => opts.MapFrom(ano => ano.AnoModelo));
        }
    }
}
