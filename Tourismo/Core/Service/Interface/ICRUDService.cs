using System;
using System.Collections.Generic;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Service.Interface
{
    public interface ICRUDService<T> where T : IBaseEntity
    {
        IEnumerable<T> ReadAll();

        T Read(Guid id);

        T Create(T entity);

        T Update(T entity);

        T Delete(Guid id);
    }
}
