using System.Collections.Generic;

namespace CheckFipe.Domain.Entities
{
    public class Marca : BaseEntity
    {
        public string Nome { get; set; }

        public IList<Modelo> Modelos { get; set; }
    }
}
