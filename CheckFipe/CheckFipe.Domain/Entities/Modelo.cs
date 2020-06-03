using System.Collections.Generic;

namespace CheckFipe.Domain.Entities
{
    public class Modelo : BaseEntity
    {
        public string Nome { get; set; }
        public long IdMarca { get; set; }
        public Marca Marca { get; set; }
        public IList<Veiculo> Veiculos { get; set; }
    }
}
