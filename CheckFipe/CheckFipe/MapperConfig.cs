﻿using AutoMapper;
using CheckFipe.Application;
using CheckFipe.Application.CarregarConsultasVeiculos;
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
        }
    }
}