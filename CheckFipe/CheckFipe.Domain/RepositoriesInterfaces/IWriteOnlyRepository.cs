using CheckFipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFipe.Domain.RepositoriesInterfaces
{
    public interface IWriteOnlyRepository<T> where T : BaseEntity
    {
        void Cadastrar(T objeto);
        void Atualizar(T objeto);
    }
}
