using AutoMapper;
using CheckFipe.Application.CarregarConsultasVeiculos;
using CheckFipe.Application.CarregarVeiculosMaisProcurados;
using CheckFipe.Domain.RepositoriesInterfaces;
using CheckFipe.Infrastructure.Data.Contexts;
using CheckFipe.Infrastructure.Data.Interfaces;
using CheckFipe.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace CheckFipe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("AllowSpecificOrigin", policy => policy.WithOrigins("http://localhost:8080"));
                option.AddPolicy("AllowAnyMethod", policy => policy.AllowAnyMethod());
            });
            services.AddControllers();
            services.AddDbContext<CheckFipeContext>(options => options.UseInMemoryDatabase("CheckFipeContext"));

            services.AddScoped<ICheckFipeContext, CheckFipeContext>();
            services.AddScoped<IConsultaVeiculoReadOnlyRepository, ConsultaVeiculoRepository>();
            services.AddScoped<IVeiculoReadOnlyRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoWriteOnlyRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoWriteReadRepository, VeiculoRepository>();
            services.AddScoped<ICarregarConsultasVeiculosUseCase, CarregarConsultasVeiculosUseCase>();
            services.AddScoped<ICarregarVeiculosMaisProcuradosUseCase, CarregarVeiculosMaisProcuradosUseCase>();

            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(configSwagger =>
            {
                configSwagger.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Check Fipe",
                        Version = "v1",
                        Description = "Serviços para consulta de marcas, modelos, versões e preço de um veículo na tabela fipe.",
                        Contact = new OpenApiContact
                        {
                            Name = "Ana Paula dos Santos",
                            Url = new Uri("https://github.com/anasantos11")
                        }
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                configSwagger.IncludeXmlComments(xmlPath);
#pragma warning disable CS0618 // Type or member is obsolete
                configSwagger.DescribeAllEnumsAsStrings();
#pragma warning restore CS0618 // Type or member is obsolete
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(configSwagger =>
            {
                configSwagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Check Fipe v1");
                configSwagger.RoutePrefix = string.Empty;
            });
        }
    }
}
