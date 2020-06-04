using CheckFipe.Domain.Entities;
using System.Collections.Generic;

namespace CheckFipe.Domain.Interfaces
{
    public interface IReadOnlyRepository<T> where T : BaseEntity
    {
        IEnumerable<T> Carregar();
    }
}
