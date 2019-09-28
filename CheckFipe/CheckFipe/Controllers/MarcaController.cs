using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckFipe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckFipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        public List<Marca> Marcas = new List<Marca>()
        {
            new Marca()
            {
                NomeMarca = "Fiat",
                CodigoMarca = 1
            },
            new Marca()
            {
                NomeMarca = "Ford",
                CodigoMarca = 2
            }
        };

        [HttpGet]
        public IEnumerable<Marca> Get()
        {
            return this.Marcas;
        }

        [HttpGet("{codigoMarca}", Name = "Get")]
        public Marca Get(long codigoMarca)
        {
            return this.Marcas.FirstOrDefault(marca => marca.CodigoMarca == codigoMarca);
        }

        [HttpPost]
        public void Post([FromBody] Marca marca)
        {
            this.Marcas.Add(marca);
        }

        [HttpPut("{codigoMarca}")]
        public void Put(long codigoMarca, [FromBody] Marca marca)
        {
            Marca marcaParaAtualizar = this.Marcas.FirstOrDefault(marca => marca.CodigoMarca == codigoMarca);
            marcaParaAtualizar = marca;
        }


        [HttpDelete("{codigoMarca}")]
        public void Delete(long codigoMarca)
        {
            this.Marcas.Remove(this.Marcas.FirstOrDefault(marca => marca.CodigoMarca == codigoMarca));
        }
    }
}
