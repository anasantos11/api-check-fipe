using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CheckFipe.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

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
            services.AddControllers();
            services.AddDbContext<CheckFipeContext>(options => options.UseInMemoryDatabase("CheckFipeContext"));
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
                configSwagger.DescribeAllEnumsAsStrings();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
            });
        }
    }
}
