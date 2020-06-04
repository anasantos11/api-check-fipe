using CheckFipe.Domain.Entities;
using System.Collections.Generic;

namespace CheckFipe.Domain.RepositoriesInterfaces
{
    public interface IReadOnlyRepository<T> where T : BaseEntity
    {
        IEnumerable<T> Carregar();
    }
}
