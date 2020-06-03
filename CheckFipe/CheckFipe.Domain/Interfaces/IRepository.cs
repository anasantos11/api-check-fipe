using CheckFipe.Domain.Entities;
using System.Collections.Generic;

namespace CheckFipe.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Cadastrar(T objeto);
        IEnumerable<T> Carregar();
    }
}
